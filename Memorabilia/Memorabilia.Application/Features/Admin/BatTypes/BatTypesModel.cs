namespace Memorabilia.Application.Features.Admin.BatTypes;

public class BatTypesModel : DomainsModel
{
    public BatTypesModel() { }

    public BatTypesModel(IEnumerable<Entity.DomainEntity> domainEntities) 
        : base(domainEntities) { }

    public override string ItemTitle 
        => Constant.AdminDomainItem.BatTypes.Item;

    public override string PageTitle 
        => Constant.AdminDomainItem.BatTypes.Title;

    public override string RoutePrefix 
        => Constant.AdminDomainItem.BatTypes.Page;
}
