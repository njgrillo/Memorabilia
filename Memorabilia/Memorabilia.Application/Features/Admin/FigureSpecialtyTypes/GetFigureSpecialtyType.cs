namespace Memorabilia.Application.Features.Admin.FigureSpecialtyTypes;

public record GetFigureSpecialtyType(int Id) : IQuery<Entity.DomainEntity>
{
    public class Handler(IDomainRepository<Entity.FigureSpecialtyType> figureSpecialtyTypeRepository) 
        : QueryHandler<GetFigureSpecialtyType, Entity.DomainEntity>
    {
        protected override async Task<Entity.DomainEntity> Handle(GetFigureSpecialtyType query)
            => await figureSpecialtyTypeRepository.Get(query.Id);
    }
}
