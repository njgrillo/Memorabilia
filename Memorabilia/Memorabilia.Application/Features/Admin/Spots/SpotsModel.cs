namespace Memorabilia.Application.Features.Admin.Spots;

public class SpotsModel : DomainsModel
{
    public SpotsModel() { }

    public SpotsModel(IEnumerable<Entity.DomainEntity> domainEntities) 
        : base(domainEntities) { }

    public override string ItemTitle 
        => Constant.AdminDomainItem.Spots.Item;

    public override string PageTitle 
        => Constant.AdminDomainItem.Spots.Title;

    public override string RoutePrefix 
        => Constant.AdminDomainItem.Spots.Page;
}
