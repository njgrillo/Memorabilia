namespace Memorabilia.Application.Features.Admin.ItemTypeBrand;

public class ItemTypeBrandsModel : Model
{
    public ItemTypeBrandsModel() { }

    public ItemTypeBrandsModel(IEnumerable<Entity.ItemTypeBrand> itemTypeBrands)
    {
        ItemTypeBrands = itemTypeBrands.Select(itemTypeBrand => new ItemTypeBrandModel(itemTypeBrand))
                                       .OrderBy(itemTypeBrand => itemTypeBrand.ItemTypeName)
                                       .ThenBy(itemTypeBrand => itemTypeBrand.BrandName)
                                       .ToList();
    }

    public string AddRoute 
        => $"{RoutePrefix}/{Constant.EditModeType.Update.Name}/0";

    public string AddTitle 
        => $"{Constant.EditModeType.Add.Name} {ItemTitle}";

    public List<ItemTypeBrandModel> ItemTypeBrands { get; set; } 
        = new();

    public override string ItemTitle 
        => Constant.AdminDomainItem.ItemTypeBrands.Item;

    public override string PageTitle 
        => Constant.AdminDomainItem.ItemTypeBrands.Title;

    public override string RoutePrefix 
        => Constant.AdminDomainItem.ItemTypeBrands.Page;
}
