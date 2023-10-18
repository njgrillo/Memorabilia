namespace Memorabilia.Domain.Entities;

public class ItemTypeSport : DomainIdEntity
{
    public ItemTypeSport() { }

    public ItemTypeSport(int itemTypeId, int sportId)
    {
        ItemTypeId = itemTypeId;
        SportId = sportId;
    }

    public int ItemTypeId { get; private set; }

    public string ItemTypeName => Constants.ItemType.Find(ItemTypeId)?.Name;

    public int SportId { get; private set; }

    public string SportName => Constants.Sport.Find(SportId)?.Name;

    public void Set(int sportId)
    {
        SportId = sportId;
    }
}
