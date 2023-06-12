namespace Memorabilia.Application.Features.Admin.ItemTypeLevel;

public class ItemTypeLevelModel : IWithValue<int>, IWithName
{
    private readonly Entity.ItemTypeLevel _itemTypeLevel;

    public ItemTypeLevelModel() { }

    public ItemTypeLevelModel(Entity.ItemTypeLevel itemTypeLevel)
    {
        _itemTypeLevel = itemTypeLevel;
    }

    public string DeleteText 
        => $"Delete {Constant.AdminDomainItem.ItemTypeLevels.Item}";

    public int Id 
        => _itemTypeLevel.Id;

    public int ItemTypeId 
        => _itemTypeLevel.ItemTypeId;

    public string ItemTypeName 
        => Constant.ItemType.Find(ItemTypeId).Name;

    public int LevelTypeId 
        => _itemTypeLevel.LevelTypeId;

    public string LevelTypeName 
        => Constant.LevelType.Find(LevelTypeId).Name;

    string IWithName.Name 
        => LevelTypeName;

    int IWithValue<int>.Value 
        => LevelTypeId;    
}
