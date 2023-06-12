namespace Memorabilia.Application.Features.Admin.Conditions;

public class ConditionsModel : DomainsModel
{
    public ConditionsModel() { }

    public ConditionsModel(IEnumerable<Entity.DomainEntity> domainEntities) 
        : base(domainEntities) { }

    public override string ItemTitle 
        => Constant.AdminDomainItem.Conditions.Item;

    public override string PageTitle
        => Constant.AdminDomainItem.Conditions.Title;

    public override string RoutePrefix 
        => Constant.AdminDomainItem.Conditions.Page;
}
