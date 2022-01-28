namespace Memorabilia.Domain.Entities
{
    public class ItemTypeSport : Framework.Domain.Entity.DomainEntity
    {
        public ItemTypeSport() { }

        public ItemTypeSport(int itemTypeId, int sportId)
        {
            ItemTypeId = itemTypeId;
            SportId = sportId;
        }

        public int ItemTypeId { get; private set; }

        public int SportId { get; private set; }

        public void Set(int sportId)
        {
            SportId = sportId;
        }
    }
}
