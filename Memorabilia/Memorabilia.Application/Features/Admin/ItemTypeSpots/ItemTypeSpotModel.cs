namespace Memorabilia.Application.Features.Admin.ItemTypeSpots;

public class ItemTypeSpotModel : IWithValue<int>, IWithName
{
    private readonly Entity.ItemTypeSpot _itemTypeSpot;

    public ItemTypeSpotModel() { }

    public ItemTypeSpotModel(Entity.ItemTypeSpot itemTypeSpot)
    {
        _itemTypeSpot = itemTypeSpot;
    }

    public string DeleteText 
        => $"Delete {Constant.AdminDomainItem.ItemTypeSpots.Item}";

    public int Id 
        => _itemTypeSpot.Id;

    public int ItemTypeId 
        => _itemTypeSpot.ItemTypeId;

    public string ItemTypeName 
        => Constant.ItemType.Find(ItemTypeId).Name;

    string IWithName.Name 
        => SpotName;

    public int SpotId 
        => _itemTypeSpot.SpotId;

    public string SpotName 
        => Constant.Spot.Find(SpotId).Name;    

    int IWithValue<int>.Value 
        => SpotId;
}
