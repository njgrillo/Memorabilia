namespace Memorabilia.Application.Features.Admin.TeamRoleTypes;

public record GetTeamRoleTypes() : IQuery<Entity.TeamRoleType[]>
{
    public class Handler : QueryHandler<GetTeamRoleTypes, Entity.TeamRoleType[]>
    {
        private readonly IDomainRepository<Entity.TeamRoleType> _TeamRoleTypeRepository;

        public Handler(IDomainRepository<Entity.TeamRoleType> TeamRoleTypeRepository)
        {
            _TeamRoleTypeRepository = TeamRoleTypeRepository;
        }

        protected override async Task<Entity.TeamRoleType[]> Handle(GetTeamRoleTypes query)
            => (await _TeamRoleTypeRepository.GetAll())
                    .ToArray();
    }
}
