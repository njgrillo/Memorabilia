using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.TeamRoleTypes;

public record GetTeamRoleType(int Id) : IQuery<DomainViewModel>
{
    public class Handler : QueryHandler<GetTeamRoleType, DomainViewModel>
    {
        private readonly IDomainRepository<TeamRoleType> _TeamRoleTypeRepository;

        public Handler(IDomainRepository<TeamRoleType> TeamRoleTypeRepository)
        {
            _TeamRoleTypeRepository = TeamRoleTypeRepository;
        }

        protected override async Task<DomainViewModel> Handle(GetTeamRoleType query)
        {
            return new DomainViewModel(await _TeamRoleTypeRepository.Get(query.Id));
        }
    }
}
