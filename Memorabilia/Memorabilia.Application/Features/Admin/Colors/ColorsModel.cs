namespace Memorabilia.Application.Features.Admin.Colors;

public class ColorsModel : DomainsModel
{
    public ColorsModel() { }

    public ColorsModel(IEnumerable<Entity.DomainEntity> domainEntities) 
        : base(domainEntities) { }

    public override string ItemTitle 
        => Constant.AdminDomainItem.Colors.Item;

    public override string PageTitle 
        => Constant.AdminDomainItem.Colors.Title;

    public override string RoutePrefix 
        => Constant.AdminDomainItem.Colors.Page;
}
