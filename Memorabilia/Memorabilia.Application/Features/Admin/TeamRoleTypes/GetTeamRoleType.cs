namespace Memorabilia.Application.Features.Admin.TeamRoleTypes;

public record GetTeamRoleType(int Id) : IQuery<Entity.DomainEntity>
{
    public class Handler(IDomainRepository<Entity.TeamRoleType> repository) 
        : QueryHandler<GetTeamRoleType, Entity.DomainEntity>
    {
        protected override async Task<Entity.DomainEntity> Handle(GetTeamRoleType query)
            => await repository.Get(query.Id);
    }
}
