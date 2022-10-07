using Memorabilia.Domain.Constants;
using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Spots;

public class SpotsViewModel : DomainsViewModel
{
    public SpotsViewModel() { }

    public SpotsViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

    public override string ItemTitle => AdminDomainItem.Spots.Item;

    public override string PageTitle => AdminDomainItem.Spots.Title;

    public override string RoutePrefix => AdminDomainItem.Spots.Page;
}
