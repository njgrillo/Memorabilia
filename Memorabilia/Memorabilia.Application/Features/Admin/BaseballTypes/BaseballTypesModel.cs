namespace Memorabilia.Application.Features.Admin.BaseballTypes;

public class BaseballTypesModel : DomainsModel
{
    public BaseballTypesModel() { }

    public BaseballTypesModel(IEnumerable<Entity.DomainEntity> domainEntities) 
        : base(domainEntities) { }

    public override string ItemTitle 
        => Constant.AdminDomainItem.BaseballTypes.Item;

    public override string PageTitle 
        => Constant.AdminDomainItem.BaseballTypes.Title;

    public override string RoutePrefix 
        => Constant.AdminDomainItem.BaseballTypes.Page;
}