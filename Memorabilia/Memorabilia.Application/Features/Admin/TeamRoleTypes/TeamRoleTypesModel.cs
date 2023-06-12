namespace Memorabilia.Application.Features.Admin.TeamRoleTypes;

public class TeamRoleTypesModel : DomainsModel
{
    public TeamRoleTypesModel() { }

    public TeamRoleTypesModel(IEnumerable<Entity.DomainEntity> domainEntities) 
        : base(domainEntities) { }

    public override string ItemTitle 
        => Constant.AdminDomainItem.TeamRoleTypes.Item;

    public override string PageTitle 
        => Constant.AdminDomainItem.TeamRoleTypes.Title;

    public override string RoutePrefix 
        => Constant.AdminDomainItem.TeamRoleTypes.Page;
}
