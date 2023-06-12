namespace Memorabilia.Application.Features.Admin.LeaderTypes;

public class LeaderTypesModel : DomainsModel
{
    public LeaderTypesModel() { }

    public LeaderTypesModel(IEnumerable<Entity.DomainEntity> domainEntities) 
        : base(domainEntities) { }

    public override string ItemTitle 
        => Constant.AdminDomainItem.LeaderTypes.Item;

    public override string PageTitle 
        => Constant.AdminDomainItem.LeaderTypes.Title;

    public override string RoutePrefix 
        => Constant.AdminDomainItem.LeaderTypes.Page;
}
