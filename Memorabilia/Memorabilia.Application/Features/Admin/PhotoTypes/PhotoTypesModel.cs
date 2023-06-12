namespace Memorabilia.Application.Features.Admin.PhotoTypes;

public class PhotoTypesModel : DomainsModel
{
    public PhotoTypesModel() { }

    public PhotoTypesModel(IEnumerable<Entity.DomainEntity> domainEntities) 
        : base(domainEntities) { }

    public override string ItemTitle 
        => Constant.AdminDomainItem.PhotoTypes.Item;

    public override string PageTitle 
        => Constant.AdminDomainItem.PhotoTypes.Title;

    public override string RoutePrefix 
        => Constant.AdminDomainItem.PhotoTypes.Page;
}
