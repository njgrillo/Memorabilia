using Memorabilia.Domain.Constants;
using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.PurchaseTypes;

public class PurchaseTypesViewModel : DomainsViewModel
{
    public PurchaseTypesViewModel() { }

    public PurchaseTypesViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

    public override string ItemTitle => AdminDomainItem.PurchaseTypes.Item;

    public override string PageTitle => AdminDomainItem.PurchaseTypes.Title;

    public override string RoutePrefix => AdminDomainItem.PurchaseTypes.Page;
}
