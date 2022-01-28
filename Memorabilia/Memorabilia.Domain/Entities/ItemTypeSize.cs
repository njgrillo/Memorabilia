namespace Memorabilia.Domain.Entities
{
    public class ItemTypeSize : Framework.Domain.Entity.DomainEntity
    {
        public ItemTypeSize() { }

        public ItemTypeSize(int itemTypeId, int sizeId)
        {
            ItemTypeId = itemTypeId;
            SizeId = sizeId;
        }

        public int ItemTypeId { get; private set; }

        public int SizeId { get; private set; }

        public void Set(int sizeId)
        {
            SizeId = sizeId;
        }
    }
}
