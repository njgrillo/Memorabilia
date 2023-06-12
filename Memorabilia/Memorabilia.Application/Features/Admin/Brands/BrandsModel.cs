namespace Memorabilia.Application.Features.Admin.Brands;

public class BrandsModel : DomainsModel
{
    public BrandsModel() { }

    public BrandsModel(IEnumerable<Entity.DomainEntity> domainEntities) 
        : base(domainEntities) { }

    public override string ItemTitle 
        => Constant.AdminDomainItem.Brands.Item;

    public override string PageTitle 
        => Constant.AdminDomainItem.Brands.Title;

    public override string RoutePrefix 
        => Constant.AdminDomainItem.Brands.Page;
}
