namespace Memorabilia.Application.Features.Admin.LevelTypes;

public class LevelTypesModel : DomainsModel
{
    public LevelTypesModel() { }

    public LevelTypesModel(IEnumerable<Entity.DomainEntity> domainEntities) 
        : base(domainEntities) { }

    public override string ItemTitle 
        => Constant.AdminDomainItem.LevelTypes.Item;

    public override string PageTitle 
        => Constant.AdminDomainItem.LevelTypes.Title;

    public override string RoutePrefix 
        => Constant.AdminDomainItem.LevelTypes.Page;
}
