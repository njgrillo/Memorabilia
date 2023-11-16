namespace Memorabilia.Application.Features.Admin.FigureTypes;

[AuthorizeByRole(Enum.Role.Admin)]
public record SaveFigureType(DomainEditModel FigureType) : ICommand
{
    public class Handler(IDomainRepository<Entity.FigureType> figureTypeRepository) 
        : CommandHandler<SaveFigureType>
    {
        protected override async Task Handle(SaveFigureType request)
        {
            Entity.FigureType figureType;

            if (request.FigureType.IsNew)
            {
                figureType = new Entity.FigureType(request.FigureType.Name, 
                                                   request.FigureType.Abbreviation);

                await figureTypeRepository.Add(figureType);

                return;
            }

            figureType = await figureTypeRepository.Get(request.FigureType.Id);

            if (request.FigureType.IsDeleted)
            {
                await figureTypeRepository.Delete(figureType);

                return;
            }

            figureType.Set(request.FigureType.Name, 
                          request.FigureType.Abbreviation);

            await figureTypeRepository.Update(figureType);
        }
    }
}
