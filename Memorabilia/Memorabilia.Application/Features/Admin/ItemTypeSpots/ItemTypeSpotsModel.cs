namespace Memorabilia.Application.Features.Admin.ItemTypeSpots;

public class ItemTypeSpotsModel : Model
{
    public ItemTypeSpotsModel() { }

    public ItemTypeSpotsModel(IEnumerable<Entity.ItemTypeSpot> itemTypeSpots)
    {
        ItemTypeSpots = itemTypeSpots.Select(ItemTypeSpot => new ItemTypeSpotModel(ItemTypeSpot))
                                     .OrderBy(itemTypeSpot => itemTypeSpot.ItemTypeName)
                                     .ThenBy(itemTypeSpot => itemTypeSpot.SpotName)
                                     .ToList();
    }

    public string AddRoute 
        => $"{RoutePrefix}/{Constant.EditModeType.Update.Name}/0";

    public string AddTitle 
        => $"{Constant.EditModeType.Add.Name} {ItemTitle}";

    public List<ItemTypeSpotModel> ItemTypeSpots { get; set; } 
        = [];

    public override string ItemTitle 
        => Constant.AdminDomainItem.ItemTypeSpots.Item;

    public override string PageTitle 
        => Constant.AdminDomainItem.ItemTypeSpots.Title;

    public override string RoutePrefix 
        => Constant.AdminDomainItem.ItemTypeSpots.Page;
}
