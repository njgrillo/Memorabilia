namespace Memorabilia.Application.Features.Admin.Colleges;

public class CollegesModel : DomainsModel
{
    public CollegesModel() { }

    public CollegesModel(IEnumerable<Entity.DomainEntity> domainEntities) 
        : base(domainEntities) { }

    public override string ItemTitle 
        => Constant.AdminDomainItem.Colleges.Item;

    public override string PageTitle 
        => Constant.AdminDomainItem.Colleges.Title;

    public override string RoutePrefix
        => Constant.AdminDomainItem.Colleges.Page;
}
