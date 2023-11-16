namespace Memorabilia.Application.Features.Admin.TeamRoleTypes;

public record GetTeamRoleTypes() : IQuery<Entity.TeamRoleType[]>
{
    public class Handler(IDomainRepository<Entity.TeamRoleType> repository) 
        : QueryHandler<GetTeamRoleTypes, Entity.TeamRoleType[]>
    {
        protected override async Task<Entity.TeamRoleType[]> Handle(GetTeamRoleTypes query)
            => await repository.GetAll();
    }
}
