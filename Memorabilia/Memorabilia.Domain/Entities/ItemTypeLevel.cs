namespace Memorabilia.Domain.Entities
{
    public class ItemTypeLevel : Framework.Domain.Entity.DomainEntity
    {
        public ItemTypeLevel() { }

        public ItemTypeLevel(int itemTypeId, int levelTypeId)
        {
            ItemTypeId = itemTypeId;
            LevelTypeId = levelTypeId;
        }

        public int LevelTypeId { get; private set; }

        public int ItemTypeId { get; private set; }

        public void Set(int levelTypeId)
        {
            LevelTypeId = levelTypeId;
        }
    }
}
