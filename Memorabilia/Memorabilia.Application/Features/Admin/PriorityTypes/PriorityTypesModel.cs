namespace Memorabilia.Application.Features.Admin.PriorityTypes;

public class PriorityTypesModel : DomainsModel
{
    public PriorityTypesModel() { }

    public PriorityTypesModel(IEnumerable<Entity.DomainEntity> domainEntities) 
        : base(domainEntities) { }

    public override string ItemTitle 
        => Constant.AdminDomainItem.PriorityTypes.Item;

    public override string PageTitle 
        => Constant.AdminDomainItem.PriorityTypes.Title;

    public override string RoutePrefix 
        => Constant.AdminDomainItem.PriorityTypes.Page;
}
