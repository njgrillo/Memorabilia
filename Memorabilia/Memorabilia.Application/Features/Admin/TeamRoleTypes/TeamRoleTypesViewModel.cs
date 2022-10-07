using Memorabilia.Domain.Constants;
using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.TeamRoleTypes;

public class TeamRoleTypesViewModel : DomainsViewModel
{
    public TeamRoleTypesViewModel() { }

    public TeamRoleTypesViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

    public override string ItemTitle => AdminDomainItem.TeamRoleTypes.Item;

    public override string PageTitle => AdminDomainItem.TeamRoleTypes.Title;

    public override string RoutePrefix => AdminDomainItem.TeamRoleTypes.Page;
}
