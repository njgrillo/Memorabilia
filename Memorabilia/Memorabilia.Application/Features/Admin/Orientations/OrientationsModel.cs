namespace Memorabilia.Application.Features.Admin.Orientations;

public class OrientationsModel : DomainsModel
{
    public OrientationsModel() { }

    public OrientationsModel(IEnumerable<Entity.DomainEntity> domainEntities) 
        : base(domainEntities) { }

    public override string ItemTitle 
        => Constant.AdminDomainItem.Orientations.Item;

    public override string PageTitle 
        => Constant.AdminDomainItem.Orientations.Title;

    public override string RoutePrefix 
        => Constant.AdminDomainItem.Orientations.Page;
}
