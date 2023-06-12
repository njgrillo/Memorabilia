namespace Memorabilia.Application.Features.Admin.JerseyStyleTypes;

public class JerseyStyleTypesModel : DomainsModel
{
    public JerseyStyleTypesModel() { }

    public JerseyStyleTypesModel(IEnumerable<Entity.DomainEntity> domainEntities) 
        : base(domainEntities) { }

    public override string ItemTitle 
        => Constant.AdminDomainItem.JerseyStyleTypes.Item;

    public override string PageTitle 
        => Constant.AdminDomainItem.JerseyStyleTypes.Title;

    public override string RoutePrefix 
        => Constant.AdminDomainItem.JerseyStyleTypes.Page;
}
