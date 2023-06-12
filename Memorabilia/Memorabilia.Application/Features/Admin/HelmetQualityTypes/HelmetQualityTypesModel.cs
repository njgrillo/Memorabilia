namespace Memorabilia.Application.Features.Admin.HelmetQualityTypes;

public class HelmetQualityTypesModel : DomainsModel
{
    public HelmetQualityTypesModel() { }

    public HelmetQualityTypesModel(IEnumerable<Entity.DomainEntity> domainEntities) 
        : base(domainEntities) { }

    public override string ItemTitle 
        => Constant.AdminDomainItem.HelmetQualityTypes.Item;

    public override string PageTitle 
        => Constant.AdminDomainItem.HelmetQualityTypes.Title;

    public override string RoutePrefix 
        => Constant.AdminDomainItem.HelmetQualityTypes.Page;
}