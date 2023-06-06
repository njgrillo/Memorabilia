using Memorabilia.Domain.Constants;
using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.ItemTypeSpots;

public class ItemTypeSpotViewModel : IWithValue<int>, IWithName
{
    private readonly ItemTypeSpot _itemTypeSpot;

    public ItemTypeSpotViewModel() { }

    public ItemTypeSpotViewModel(ItemTypeSpot itemTypeSpot)
    {
        _itemTypeSpot = itemTypeSpot;
    }

    public string DeleteText => $"Delete {AdminDomainItem.ItemTypeSpots.Item}";

    public int Id => _itemTypeSpot.Id;

    public int ItemTypeId => _itemTypeSpot.ItemTypeId;

    public string ItemTypeName => Constant.ItemType.Find(ItemTypeId).Name;

    string IWithName.Name => SpotName;

    public int SpotId => _itemTypeSpot.SpotId;

    public string SpotName => Constant.Spot.Find(SpotId).Name;    

    int IWithValue<int>.Value => SpotId;
}
