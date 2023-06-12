namespace Memorabilia.Application.Features.Admin.BasketballTypes;

public class BasketballTypesModel : DomainsModel
{
    public BasketballTypesModel() { }

    public BasketballTypesModel(IEnumerable<Entity.DomainEntity> domainEntities) 
        : base(domainEntities) { }

    public override string ItemTitle 
        => Constant.AdminDomainItem.BasketballTypes.Item;

    public override string PageTitle 
        => Constant.AdminDomainItem.BasketballTypes.Title;

    public override string RoutePrefix 
        => Constant.AdminDomainItem.BasketballTypes.Page;
}
