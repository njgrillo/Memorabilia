namespace Memorabilia.Application.Features.Admin.PrivacyTypes;

public class PrivacyTypesModel : DomainsModel
{
    public PrivacyTypesModel() { }

    public PrivacyTypesModel(IEnumerable<Entity.DomainEntity> domainEntities) :
        base(domainEntities) { }

    public override string ItemTitle 
        => Constant.AdminDomainItem.PrivacyTypes.Item;

    public override string PageTitle 
        => Constant.AdminDomainItem.PrivacyTypes.Title;

    public override string RoutePrefix 
        => Constant.AdminDomainItem.PrivacyTypes.Page;
}
