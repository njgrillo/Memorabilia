namespace Memorabilia.Application.Features.Admin.BammerTypes;

public class BammerTypesModel : DomainsModel
{
    public BammerTypesModel() { }

    public BammerTypesModel(IEnumerable<Entity.DomainEntity> domainEntities) 
        : base(domainEntities) { }

    public override string ItemTitle 
        => Constant.AdminDomainItem.BammerTypes.Item;

    public override string PageTitle 
        => Constant.AdminDomainItem.BammerTypes.Title;

    public override string RoutePrefix 
        => Constant.AdminDomainItem.BammerTypes.Page;
}
