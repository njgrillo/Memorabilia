namespace Memorabilia.Application.Features.Admin.FootballTypes;

public class FootballTypesModel : DomainsModel
{
    public FootballTypesModel() { }

    public FootballTypesModel(IEnumerable<Entity.DomainEntity> domainEntities) 
        : base(domainEntities) { }

    public override string ItemTitle 
        => Constant.AdminDomainItem.FootballTypes.Item;

    public override string PageTitle 
        => Constant.AdminDomainItem.FootballTypes.Title;

    public override string RoutePrefix 
        => Constant.AdminDomainItem.FootballTypes.Page;
}
