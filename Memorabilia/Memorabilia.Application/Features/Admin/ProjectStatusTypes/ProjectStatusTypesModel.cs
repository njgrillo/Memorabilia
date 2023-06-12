namespace Memorabilia.Application.Features.Admin.ProjectStatusTypes;

public class ProjectStatusTypesModel : DomainsModel
{
    public ProjectStatusTypesModel() { }

    public ProjectStatusTypesModel(IEnumerable<Entity.DomainEntity> domainEntities) 
        : base(domainEntities) { }

    public override string ItemTitle 
        => Constant.AdminDomainItem.ProjectStatusTypes.Item;

    public override string PageTitle 
        => Constant.AdminDomainItem.ProjectStatusTypes.Title;

    public override string RoutePrefix 
        => Constant.AdminDomainItem.ProjectStatusTypes.Page;
}
