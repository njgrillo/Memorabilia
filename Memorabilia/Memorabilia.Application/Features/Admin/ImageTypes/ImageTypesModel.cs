namespace Memorabilia.Application.Features.Admin.ImageTypes;

public class ImageTypesModel : DomainsModel
{
    public ImageTypesModel() { }

    public ImageTypesModel(IEnumerable<Entity.DomainEntity> domainEntities) 
        : base(domainEntities) { }

    public override string ItemTitle 
        => Constant.AdminDomainItem.ImageTypes.Item;

    public override string PageTitle 
        => Constant.AdminDomainItem.ImageTypes.Title;

    public override string RoutePrefix 
        => Constant.AdminDomainItem.ImageTypes.Page;
}
