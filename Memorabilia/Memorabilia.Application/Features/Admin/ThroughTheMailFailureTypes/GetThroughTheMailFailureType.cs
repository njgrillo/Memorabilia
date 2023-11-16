namespace Memorabilia.Application.Features.Admin.ThroughTheMailFailureTypes;

public record GetThroughTheMailFailureType(int Id) : IQuery<Entity.DomainEntity>
{
    public class Handler(IDomainRepository<Entity.TeamRoleType> repository) 
        : QueryHandler<GetThroughTheMailFailureType, Entity.DomainEntity>
    {
        protected override async Task<Entity.DomainEntity> Handle(GetThroughTheMailFailureType query)
            => await repository.Get(query.Id);
    }
}
