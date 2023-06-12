namespace Memorabilia.Application.Features.Admin.GloveTypes;

public class GloveTypesModel : DomainsModel
{
    public GloveTypesModel() { }

    public GloveTypesModel(IEnumerable<Entity.DomainEntity> domainEntities) 
        : base(domainEntities) { }

    public override string ItemTitle 
        => Constant.AdminDomainItem.GloveTypes.Item;

    public override string PageTitle 
        => Constant.AdminDomainItem.GloveTypes.Title;

    public override string RoutePrefix 
        => Constant.AdminDomainItem.GloveTypes.Page;
}
