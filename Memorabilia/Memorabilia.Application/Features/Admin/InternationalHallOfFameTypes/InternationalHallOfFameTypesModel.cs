namespace Memorabilia.Application.Features.Admin.InternationalHallOfFameTypes;

public class InternationalHallOfFameTypesModel : DomainsModel
{
    public InternationalHallOfFameTypesModel() { }

    public InternationalHallOfFameTypesModel(IEnumerable<Entity.DomainEntity> domainEntities) 
        : base(domainEntities) { }

    public override string ItemTitle 
        => Constant.AdminDomainItem.InternationalHallOfFameTypes.Item;

    public override string PageTitle 
        => Constant.AdminDomainItem.InternationalHallOfFameTypes.Title;

    public override string RoutePrefix 
        => Constant.AdminDomainItem.InternationalHallOfFameTypes.Page;
}
