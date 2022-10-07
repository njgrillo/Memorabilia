namespace Memorabilia.Domain.Entities;

public class ItemTypeLevel : Framework.Library.Domain.Entity.DomainEntity
{
    public ItemTypeLevel() { }

    public ItemTypeLevel(int itemTypeId, int levelTypeId)
    {
        ItemTypeId = itemTypeId;
        LevelTypeId = levelTypeId;
    }        

    public int ItemTypeId { get; private set; }

    public string ItemTypeName => Constants.ItemType.Find(ItemTypeId)?.Name;

    public int LevelTypeId { get; private set; }

    public string LevelTypeName => Constants.LevelType.Find(LevelTypeId)?.Name;

    public void Set(int levelTypeId)
    {
        LevelTypeId = levelTypeId;
    }
}
