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

        public int ItemTypeId { get; private set; }        

        public void Set(int brandId)
        {
            BrandId = brandId;
        }
    }
}
