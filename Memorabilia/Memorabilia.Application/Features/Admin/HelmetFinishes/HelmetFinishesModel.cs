namespace Memorabilia.Application.Features.Admin.HelmetFinishes;

public class HelmetFinishesModel : DomainsModel
{
    public HelmetFinishesModel() { }

    public HelmetFinishesModel(IEnumerable<Entity.DomainEntity> domainEntities) 
        : base(domainEntities) { }

    public override string ItemTitle 
        => Constant.AdminDomainItem.HelmetFinishes.Item;

    public override string PageTitle 
        => Constant.AdminDomainItem.HelmetFinishes.Title;

    public override string RoutePrefix 
        => Constant.AdminDomainItem.HelmetFinishes.Page;
}
