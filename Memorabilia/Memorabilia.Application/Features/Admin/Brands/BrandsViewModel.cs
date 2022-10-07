using Memorabilia.Domain.Constants;
using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Brands;

public class BrandsViewModel : DomainsViewModel
{
    public BrandsViewModel() { }

    public BrandsViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

    public override string ItemTitle => AdminDomainItem.Brands.Item;

    public override string PageTitle => AdminDomainItem.Brands.Title;

    public override string RoutePrefix => AdminDomainItem.Brands.Page;
}
