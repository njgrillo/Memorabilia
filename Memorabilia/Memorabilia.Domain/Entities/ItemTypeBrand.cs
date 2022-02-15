namespace Memorabilia.Domain.Entities
{
    public class ItemTypeBrand : Framework.Domain.Entity.DomainEntity
    {
        public ItemTypeBrand() { }

        public ItemTypeBrand(int itemTypeId, int brandId)
        {
            ItemTypeId = itemTypeId;
            BrandId = brandId;
        }

        public int BrandId { get; private set; }

        public string BrandName => Constants.Brand.Find(BrandId)?.Name;

        public int ItemTypeId { get; private set; }

        public string ItemTypeName => Constants.ItemType.Find(ItemTypeId)?.Name;

        public void Set(int brandId)
        {
            BrandId = brandId;
        }
    }
}
