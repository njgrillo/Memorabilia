namespace Memorabilia.Application.Features.Admin.PurchaseTypes;

public class PurchaseTypesModel : DomainsModel
{
    public PurchaseTypesModel() { }

    public PurchaseTypesModel(IEnumerable<Entity.DomainEntity> domainEntities) 
        : base(domainEntities) { }

    public override string ItemTitle 
        => Constant.AdminDomainItem.PurchaseTypes.Item;

    public override string PageTitle 
        => Constant.AdminDomainItem.PurchaseTypes.Title;

    public override string RoutePrefix 
        => Constant.AdminDomainItem.PurchaseTypes.Page;
}
