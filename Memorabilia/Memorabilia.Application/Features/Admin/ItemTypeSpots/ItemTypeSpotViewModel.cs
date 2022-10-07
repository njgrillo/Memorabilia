using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.ItemTypeSpots;

public class ItemTypeSpotViewModel
{
    private readonly ItemTypeSpot _itemTypeSpot;

    public ItemTypeSpotViewModel() { }

    public ItemTypeSpotViewModel(ItemTypeSpot itemTypeSpot)
    {
        _itemTypeSpot = itemTypeSpot;
    }

    public int Id => _itemTypeSpot.Id;

    public int ItemTypeId => _itemTypeSpot.ItemTypeId;

    public string ItemTypeName => Domain.Constants.ItemType.Find(ItemTypeId).Name;

    public int SpotId => _itemTypeSpot.SpotId;

    public string SpotName => Domain.Constants.Spot.Find(SpotId).Name;
}
