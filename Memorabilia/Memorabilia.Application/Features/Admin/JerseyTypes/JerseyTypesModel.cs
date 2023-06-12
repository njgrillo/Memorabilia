namespace Memorabilia.Application.Features.Admin.JerseyTypes;

public class JerseyTypesModel : DomainsModel
{
    public JerseyTypesModel() { }

    public JerseyTypesModel(IEnumerable<Entity.DomainEntity> domainEntities) 
        : base(domainEntities) { }

    public override string ItemTitle 
        => Constant.AdminDomainItem.JerseyTypes.Item;

    public override string PageTitle 
        => Constant.AdminDomainItem.JerseyTypes.Title;

    public override string RoutePrefix 
        => Constant.AdminDomainItem.JerseyTypes.Page;
}
