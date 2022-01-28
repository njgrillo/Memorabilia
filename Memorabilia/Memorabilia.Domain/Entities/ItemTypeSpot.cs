namespace Memorabilia.Domain.Entities
{
    public class ItemTypeSpot : Framework.Domain.Entity.DomainEntity
    {
        public ItemTypeSpot() { }

        public ItemTypeSpot(int itemTypeId, int spotId)
        {
            ItemTypeId = itemTypeId;
            SpotId = spotId;
        }

        public int ItemTypeId { get; private set; }

        public int SpotId { get; private set; }

        public void Set(int spotId)
        {
            SpotId = spotId;
        }
    }
}
