namespace Memorabilia.Application.Features.Admin.FigureTypes;

public record GetFigureType(int Id) : IQuery<Entity.DomainEntity>
{
    public class Handler(IDomainRepository<Entity.FigureType> figureTypeRepository) 
        : QueryHandler<GetFigureType, Entity.DomainEntity>
    {
        protected override async Task<Entity.DomainEntity> Handle(GetFigureType query)
            => await figureTypeRepository.Get(query.Id);
    }
}
