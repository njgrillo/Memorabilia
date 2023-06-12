namespace Memorabilia.Application.Features.Admin.TeamRoleTypes;

public record GetTeamRoleType(int Id) : IQuery<Entity.TeamRoleType>
{
    public class Handler : QueryHandler<GetTeamRoleType, Entity.TeamRoleType>
    {
        private readonly IDomainRepository<Entity.TeamRoleType> _TeamRoleTypeRepository;

        public Handler(IDomainRepository<Entity.TeamRoleType> TeamRoleTypeRepository)
        {
            _TeamRoleTypeRepository = TeamRoleTypeRepository;
        }

        protected override async Task<Entity.TeamRoleType> Handle(GetTeamRoleType query)
            => await _TeamRoleTypeRepository.Get(query.Id);
    }
}
