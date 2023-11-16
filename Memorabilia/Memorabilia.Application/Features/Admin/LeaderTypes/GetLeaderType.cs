namespace Memorabilia.Application.Features.Admin.LeaderTypes;

public record GetLeaderType(int Id) : IQuery<Entity.DomainEntity>
{
    public class Handler(IDomainRepository<Entity.LeaderType> leaderTypeRepository) 
        : QueryHandler<GetLeaderType, Entity.DomainEntity>
    {
        protected override async Task<Entity.DomainEntity> Handle(GetLeaderType query)
            => await leaderTypeRepository.Get(query.Id);
    }
}
