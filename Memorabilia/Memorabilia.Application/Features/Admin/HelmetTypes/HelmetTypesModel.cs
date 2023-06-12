namespace Memorabilia.Application.Features.Admin.HelmetTypes;

public class HelmetTypesModel : DomainsModel
{
    public HelmetTypesModel() { }

    public HelmetTypesModel(IEnumerable<Entity.DomainEntity> domainEntities) 
        : base(domainEntities) { }

    public override string ItemTitle 
        => Constant.AdminDomainItem.HelmetTypes.Item;

    public override string PageTitle 
        => Constant.AdminDomainItem.HelmetTypes.Title;

    public override string RoutePrefix
        => Constant.AdminDomainItem.HelmetTypes.Page;
}
