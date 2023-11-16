namespace Memorabilia.Application.Features.Admin.FigureSpecialtyTypes;

[AuthorizeByRole(Enum.Role.Admin)]
public record SaveFigureSpecialtyType(DomainEditModel FigureSpecialtyType) : ICommand
{
    public class Handler(IDomainRepository<Entity.FigureSpecialtyType> figureSpecialtyTypeRepository) 
        : CommandHandler<SaveFigureSpecialtyType>
    {
        protected override async Task Handle(SaveFigureSpecialtyType request)
        {
            Entity.FigureSpecialtyType figureSpecialtyType;

            if (request.FigureSpecialtyType.IsNew)
            {
                figureSpecialtyType = new Entity.FigureSpecialtyType(request.FigureSpecialtyType.Name, 
                                                                     request.FigureSpecialtyType.Abbreviation);

                await figureSpecialtyTypeRepository.Add(figureSpecialtyType);

                return;
            }

            figureSpecialtyType = await figureSpecialtyTypeRepository.Get(request.FigureSpecialtyType.Id);

            if (request.FigureSpecialtyType.IsDeleted)
            {
                await figureSpecialtyTypeRepository.Delete(figureSpecialtyType);

                return;
            }

            figureSpecialtyType.Set(request.FigureSpecialtyType.Name, 
                                    request.FigureSpecialtyType.Abbreviation);

            await figureSpecialtyTypeRepository.Update(figureSpecialtyType);
        }
    }
}
