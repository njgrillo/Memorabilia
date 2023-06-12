namespace Memorabilia.Application.Features.Admin.JerseyQualityTypes;

public class JerseyQualityTypesModel : DomainsModel
{
    public JerseyQualityTypesModel() { }

    public JerseyQualityTypesModel(IEnumerable<Entity.DomainEntity> domainEntities) 
        : base(domainEntities) { }

    public override string ItemTitle 
        => Constant.AdminDomainItem.JerseyQualityTypes.Item;

    public override string PageTitle 
        => Constant.AdminDomainItem.JerseyQualityTypes.Title;

    public override string RoutePrefix 
        => Constant.AdminDomainItem.JerseyQualityTypes.Page;
}
