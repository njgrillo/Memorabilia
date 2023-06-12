namespace Memorabilia.Application.Features.Admin.FranchiseHallOfFameTypes;

public class FranchiseHallOfFameTypesModel : DomainsModel
{
    public FranchiseHallOfFameTypesModel() { }

    public FranchiseHallOfFameTypesModel(IEnumerable<Entity.DomainEntity> domainEntities) 
        : base(domainEntities) { }

    public override string ItemTitle 
        => Constant.AdminDomainItem.FranchiseHallOfFameTypes.Item;

    public override string PageTitle 
        => Constant.AdminDomainItem.FranchiseHallOfFameTypes.Title;

    public override string RoutePrefix 
        => Constant.AdminDomainItem.FranchiseHallOfFameTypes.Page;
}
