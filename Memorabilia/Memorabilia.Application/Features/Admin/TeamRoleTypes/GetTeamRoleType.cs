namespace Memorabilia.Application.Features.Admin.TeamRoleTypes;

public record GetTeamRoleType(int Id) : IQuery<Entity.DomainEntity>
{
    public class Handler : QueryHandler<GetTeamRoleType, Entity.DomainEntity>
    {
        private readonly IDomainRepository<Entity.TeamRoleType> _TeamRoleTypeRepository;

        public Handler(IDomainRepository<Entity.TeamRoleType> TeamRoleTypeRepository)
        {
            _TeamRoleTypeRepository = TeamRoleTypeRepository;
        }

        protected override async Task<Entity.DomainEntity> Handle(GetTeamRoleType query)
            => await _TeamRoleTypeRepository.Get(query.Id);
    }
}
