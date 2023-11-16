namespace Memorabilia.Application.Features.Admin.ChampionTypes;

public record GetChampionType(int Id) : IQuery<Entity.DomainEntity>
{
    public class Handler(IDomainRepository<Entity.ChampionType> championTypeRepository) 
        : QueryHandler<GetChampionType, Entity.DomainEntity>
    {
        protected override async Task<Entity.DomainEntity> Handle(GetChampionType query)
            => await championTypeRepository.Get(query.Id);
    }
}
