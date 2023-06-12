namespace Memorabilia.Application.Features.Admin.Occupations;

public class OccupationsModel : DomainsModel
{
    public OccupationsModel() { }

    public OccupationsModel(IEnumerable<Entity.DomainEntity> domainEntities) 
        : base(domainEntities) { }

    public override string ItemTitle 
        => Constant.AdminDomainItem.Occupations.Item;

    public override string PageTitle 
        => Constant.AdminDomainItem.Occupations.Title;

    public override string RoutePrefix 
        => Constant.AdminDomainItem.Occupations.Page;
}
