namespace Memorabilia.Application.Features.Admin.AwardTypes;

public class AwardTypesModel : DomainsModel
{
    public AwardTypesModel() { }

    public AwardTypesModel(IEnumerable<Entity.DomainEntity> domainEntities) 
        : base(domainEntities) { }

    public override string ItemTitle 
        => Constant.AdminDomainItem.AwardTypes.Item;

    public override string PageTitle 
        => Constant.AdminDomainItem.AwardTypes.Title;

    public override string RoutePrefix 
        => Constant.AdminDomainItem.AwardTypes.Page;
}
