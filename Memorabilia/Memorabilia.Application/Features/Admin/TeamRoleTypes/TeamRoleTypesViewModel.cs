using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.TeamRoleTypes
{
    public class TeamRoleTypesViewModel : DomainsViewModel
    {
        public TeamRoleTypesViewModel() { }

        public TeamRoleTypesViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

        public override string ItemTitle => "Team Role Type";

        public override string PageTitle => "Team Role Types";

        public override string RoutePrefix => "TeamRoleTypes";
    }
}
