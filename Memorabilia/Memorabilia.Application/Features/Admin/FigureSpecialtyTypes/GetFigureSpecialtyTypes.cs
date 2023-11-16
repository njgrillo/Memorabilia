namespace Memorabilia.Application.Features.Admin.FigureSpecialtyTypes;

public record GetFigureSpecialtyTypes() : IQuery<Entity.FigureSpecialtyType[]>
{
    public class Handler(IDomainRepository<Entity.FigureSpecialtyType> figureSpecialtyTypeRepository) 
        : QueryHandler<GetFigureSpecialtyTypes, Entity.FigureSpecialtyType[]>
    {
        protected override async Task<Entity.FigureSpecialtyType[]> Handle(GetFigureSpecialtyTypes query)
            => await figureSpecialtyTypeRepository.GetAll();
    }
}
