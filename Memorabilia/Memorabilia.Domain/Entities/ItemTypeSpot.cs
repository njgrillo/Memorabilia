namespace Memorabilia.Domain.Entities
{
    public class ItemTypeSpot : Framework.Library.Domain.Entity.DomainEntity
    {
        public ItemTypeSpot() { }

        public ItemTypeSpot(int itemTypeId, int spotId)
        {
            ItemTypeId = itemTypeId;
            SpotId = spotId;
        }

        public int ItemTypeId { get; private set; }

        public string ItemTypeName => Constants.ItemType.Find(ItemTypeId)?.Name;

        public int SpotId { get; private set; }

        public string SpotName => Constants.ItemType.Find(SpotId)?.Name;

        public void Set(int spotId)
        {
            SpotId = spotId;
        }
    }
}
