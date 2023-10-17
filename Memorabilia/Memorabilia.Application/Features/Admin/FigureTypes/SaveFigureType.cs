namespace Memorabilia.Application.Features.Admin.FigureTypes;

[AuthorizeByRole(Enum.Role.Admin)]
public record SaveFigureType(DomainEditModel FigureType) : ICommand
{
    public class Handler : CommandHandler<SaveFigureType>
    {
        private readonly IDomainRepository<Entity.FigureType> _figureTypeRepository;

        public Handler(IDomainRepository<Entity.FigureType> figureTypeRepository)
        {
            _figureTypeRepository = figureTypeRepository;
        }

        protected override async Task Handle(SaveFigureType request)
        {
            Entity.FigureType figureType;

            if (request.FigureType.IsNew)
            {
                figureType = new Entity.FigureType(request.FigureType.Name, 
                                                   request.FigureType.Abbreviation);

                await _figureTypeRepository.Add(figureType);

                return;
            }

            figureType = await _figureTypeRepository.Get(request.FigureType.Id);

            if (request.FigureType.IsDeleted)
            {
                await _figureTypeRepository.Delete(figureType);

                return;
            }

            figureType.Set(request.FigureType.Name, 
                          request.FigureType.Abbreviation);

            await _figureTypeRepository.Update(figureType);
        }
    }
}
