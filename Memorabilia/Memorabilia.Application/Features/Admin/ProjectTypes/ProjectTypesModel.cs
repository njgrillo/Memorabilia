namespace Memorabilia.Application.Features.Admin.ProjectTypes;

public class ProjectTypesModel : DomainsModel
{
    public ProjectTypesModel() { }

    public ProjectTypesModel(IEnumerable<Entity.DomainEntity> domainEntities) 
        : base(domainEntities) { }

    public override string ItemTitle 
        => Constant.AdminDomainItem.ProjectTypes.Item;

    public override string PageTitle 
        => Constant.AdminDomainItem.ProjectTypes.Title;

    public override string RoutePrefix 
        => Constant.AdminDomainItem.ProjectTypes.Page;
}
