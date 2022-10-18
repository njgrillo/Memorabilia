using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.TeamRoleTypes;

public record GetTeamRoleTypes() : IQuery<TeamRoleTypesViewModel>
{
    public class Handler : QueryHandler<GetTeamRoleTypes, TeamRoleTypesViewModel>
    {
        private readonly IDomainRepository<TeamRoleType> _TeamRoleTypeRepository;

        public Handler(IDomainRepository<TeamRoleType> TeamRoleTypeRepository)
        {
            _TeamRoleTypeRepository = TeamRoleTypeRepository;
        }

        protected override async Task<TeamRoleTypesViewModel> Handle(GetTeamRoleTypes query)
        {
            return new TeamRoleTypesViewModel(await _TeamRoleTypeRepository.GetAll());
        }
    }
}
