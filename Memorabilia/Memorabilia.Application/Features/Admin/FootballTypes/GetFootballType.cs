namespace Memorabilia.Application.Features.Admin.FootballTypes;

public record GetFootballType(int Id) : IQuery<Entity.DomainEntity>
{
    public class Handler(IDomainRepository<Entity.FootballType> footballTypeRepository) 
        : QueryHandler<GetFootballType, Entity.DomainEntity>
    {
        protected override async Task<Entity.DomainEntity> Handle(GetFootballType query)
            => await footballTypeRepository.Get(query.Id);
    }
}
