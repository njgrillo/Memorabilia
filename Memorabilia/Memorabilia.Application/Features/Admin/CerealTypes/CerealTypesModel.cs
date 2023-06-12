namespace Memorabilia.Application.Features.Admin.CerealTypes;

public class CerealTypesModel : DomainsModel
{
    public CerealTypesModel() { }

    public CerealTypesModel(IEnumerable<Entity.DomainEntity> domainEntities) 
        : base(domainEntities) { }

    public override string ItemTitle 
        => Constant.AdminDomainItem.CerealTypes.Item;

    public override string PageTitle
        => Constant.AdminDomainItem.CerealTypes.Title;

    public override string RoutePrefix 
        => Constant.AdminDomainItem.CerealTypes.Page;
}
