namespace Memorabilia.Application.Features.Admin.MagazineTypes;

public class MagazineTypesModel : DomainsModel
{
    public MagazineTypesModel() { }

    public MagazineTypesModel(IEnumerable<Entity.DomainEntity> domainEntities) 
        : base(domainEntities) { }

    public override string ItemTitle 
        => Constant.AdminDomainItem.MagazineTypes.Item;

    public override string PageTitle 
        => Constant.AdminDomainItem.MagazineTypes.Title;

    public override string RoutePrefix 
        => Constant.AdminDomainItem.MagazineTypes.Page;
}
