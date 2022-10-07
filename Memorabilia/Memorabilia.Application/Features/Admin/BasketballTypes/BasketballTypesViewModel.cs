using Memorabilia.Domain.Constants;
using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.BasketballTypes;

public class BasketballTypesViewModel : DomainsViewModel
{
    public BasketballTypesViewModel() { }

    public BasketballTypesViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

    public override string ItemTitle => AdminDomainItem.BasketballTypes.Item;

    public override string PageTitle => AdminDomainItem.BasketballTypes.Title;

    public override string RoutePrefix => AdminDomainItem.BasketballTypes.Page;
}
