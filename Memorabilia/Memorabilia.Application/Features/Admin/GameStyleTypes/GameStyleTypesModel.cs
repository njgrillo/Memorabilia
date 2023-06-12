namespace Memorabilia.Application.Features.Admin.GameStyleTypes;

public class GameStyleTypesModel : DomainsModel
{
    public GameStyleTypesModel() { }

    public GameStyleTypesModel(IEnumerable<Entity.DomainEntity> domainEntities) 
        : base(domainEntities) { }

    public override string ItemTitle 
        => Constant.AdminDomainItem.GameStyleTypes.Item;

    public override string PageTitle 
        => Constant.AdminDomainItem.GameStyleTypes.Title;

    public override string RoutePrefix 
        => Constant.AdminDomainItem.GameStyleTypes.Page;
}
