namespace Memorabilia.Application.Features.Admin.ChampionTypes;

public class ChampionTypesModel : DomainsModel
{
    public ChampionTypesModel() { }

    public ChampionTypesModel(IEnumerable<Entity.DomainEntity> domainEntities) 
        : base(domainEntities) { }

    public override string ItemTitle 
        => Constant.AdminDomainItem.ChampionTypes.Item;

    public override string PageTitle 
        => Constant.AdminDomainItem.ChampionTypes.Title;

    public override string RoutePrefix 
        => Constant.AdminDomainItem.ChampionTypes.Page;
}
