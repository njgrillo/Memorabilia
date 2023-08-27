namespace Memorabilia.Application.Features.Admin.ThroughTheMailFailureTypes;

public class ThroughTheMailFailureTypesModel : DomainsModel
{
    public ThroughTheMailFailureTypesModel() { }

    public ThroughTheMailFailureTypesModel(IEnumerable<Entity.DomainEntity> domainEntities)
        : base(domainEntities) { }

    public override string ItemTitle
        => Constant.AdminDomainItem.ThroughTheMailFailureTypes.Item;

    public override string PageTitle
        => Constant.AdminDomainItem.ThroughTheMailFailureTypes.Title;

    public override string RoutePrefix
        => Constant.AdminDomainItem.ThroughTheMailFailureTypes.Page;
}
