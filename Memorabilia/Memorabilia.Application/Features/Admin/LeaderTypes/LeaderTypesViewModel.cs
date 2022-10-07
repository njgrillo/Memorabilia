using Memorabilia.Domain.Constants;
using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.LeaderTypes;

public class LeaderTypesViewModel : DomainsViewModel
{
    public LeaderTypesViewModel() { }

    public LeaderTypesViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

    public override string ItemTitle => AdminDomainItem.LeaderTypes.Item;

    public override string PageTitle => AdminDomainItem.LeaderTypes.Title;

    public override string RoutePrefix => AdminDomainItem.LeaderTypes.Page;
}
