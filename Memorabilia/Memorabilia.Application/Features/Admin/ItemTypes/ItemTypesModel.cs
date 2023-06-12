namespace Memorabilia.Application.Features.Admin.ItemTypes;

public class ItemTypesModel : DomainsModel
{
    public ItemTypesModel() { }

    public ItemTypesModel(IEnumerable<Entity.DomainEntity> domainEntities) 
        : base(domainEntities) { }

    public override string ItemTitle 
        => Constant.AdminDomainItem.ItemTypes.Item;

    public override string PageTitle 
        => Constant.AdminDomainItem.ItemTypes.Title;

    public override string RoutePrefix 
        => Constant.AdminDomainItem.ItemTypes.Page;
}