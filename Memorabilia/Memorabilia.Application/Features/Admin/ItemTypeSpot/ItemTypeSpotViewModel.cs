namespace Memorabilia.Application.Features.Admin.ItemTypeSpot
{
    public class ItemTypeSpotViewModel
    {
        private readonly Domain.Entities.ItemTypeSpot _itemTypeSpot;

        public ItemTypeSpotViewModel() { }

        public ItemTypeSpotViewModel(Domain.Entities.ItemTypeSpot itemTypeSpot)
        {
            _itemTypeSpot = itemTypeSpot;
        }

        public int Id => _itemTypeSpot.Id;

        public int ItemTypeId => _itemTypeSpot.ItemTypeId;

        public string ItemTypeName => Domain.Constants.ItemType.Find(ItemTypeId).Name;

        public int SpotId => _itemTypeSpot.SpotId;

        public string SpotName => Domain.Constants.Spot.Find(SpotId).Name;
    }
}
