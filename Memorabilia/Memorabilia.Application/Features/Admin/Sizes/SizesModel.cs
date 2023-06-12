namespace Memorabilia.Application.Features.Admin.Sizes;

public class SizesModel : DomainsModel
{
    public SizesModel() { }

    public SizesModel(IEnumerable<Entity.DomainEntity> domainEntities) 
        : base(domainEntities) { }

    public override string ItemTitle 
        => Constant.AdminDomainItem.Sizes.Item;

    public override string PageTitle 
        => Constant.AdminDomainItem.Sizes.Title;

    public override string RoutePrefix 
        => Constant.AdminDomainItem.Sizes.Page;
}
