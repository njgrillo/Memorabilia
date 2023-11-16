namespace Memorabilia.Application.Features.Admin.ItemTypeSizes;

public class ItemTypeSizesModel : Model
{
    public ItemTypeSizesModel() { }

    public ItemTypeSizesModel(IEnumerable<Entity.ItemTypeSize> itemTypeSizes)
    {
        ItemTypeSizes = itemTypeSizes.Select(itemTypeSize => new ItemTypeSizeModel(itemTypeSize))
                                     .OrderBy(itemTypeSize => itemTypeSize.ItemTypeName)
                                     .ThenBy(itemTypeSize => itemTypeSize.SizeName)
                                     .ToList();
    }

    public string AddRoute 
        => $"{RoutePrefix}/{Constant.EditModeType.Update.Name}/0";

    public string AddTitle 
        => $"{Constant.EditModeType.Add.Name} {ItemTitle}";

    public List<ItemTypeSizeModel> ItemTypeSizes { get; set; } 
        = [];

    public override string ItemTitle 
        => Constant.AdminDomainItem.ItemTypeSizes.Item;

    public override string PageTitle 
        => Constant.AdminDomainItem.ItemTypeSizes.Title;

    public override string RoutePrefix 
        => Constant.AdminDomainItem.ItemTypeSizes.Page;
}
