namespace Memorabilia.Application.Features.Admin.FigureSpecialtyTypes;

[AuthorizeByRole(Enum.PermissionType.Admin)]
public record SaveFigureSpecialtyType(DomainEditModel FigureSpecialtyType) : ICommand
{
    public class Handler : CommandHandler<SaveFigureSpecialtyType>
    {
        private readonly IDomainRepository<Entity.FigureSpecialtyType> _figureSpecialtyTypeRepository;

        public Handler(IDomainRepository<Entity.FigureSpecialtyType> figureSpecialtyTypeRepository)
        {
            _figureSpecialtyTypeRepository = figureSpecialtyTypeRepository;
        }

        protected override async Task Handle(SaveFigureSpecialtyType request)
        {
            Entity.FigureSpecialtyType figureSpecialtyType;

            if (request.FigureSpecialtyType.IsNew)
            {
                figureSpecialtyType = new Entity.FigureSpecialtyType(request.FigureSpecialtyType.Name, 
                                                                     request.FigureSpecialtyType.Abbreviation);

                await _figureSpecialtyTypeRepository.Add(figureSpecialtyType);

                return;
            }

            figureSpecialtyType = await _figureSpecialtyTypeRepository.Get(request.FigureSpecialtyType.Id);

            if (request.FigureSpecialtyType.IsDeleted)
            {
                await _figureSpecialtyTypeRepository.Delete(figureSpecialtyType);

                return;
            }

            figureSpecialtyType.Set(request.FigureSpecialtyType.Name, 
                                    request.FigureSpecialtyType.Abbreviation);

            await _figureSpecialtyTypeRepository.Update(figureSpecialtyType);
        }
    }
}
