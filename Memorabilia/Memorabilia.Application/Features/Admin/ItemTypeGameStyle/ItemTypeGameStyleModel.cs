namespace Memorabilia.Application.Features.Admin.ItemTypeGameStyle;

public class ItemTypeGameStyleModel : IWithValue<int>, IWithName
{
    private readonly Entity.ItemTypeGameStyleType _itemTypeGameStyle;

    public ItemTypeGameStyleModel() { }

    public ItemTypeGameStyleModel(Entity.ItemTypeGameStyleType itemTypeGameStyle)
    {
        _itemTypeGameStyle = itemTypeGameStyle;
    }

    public string DeleteText 
        => $"Delete {Constant.AdminDomainItem.ItemTypeGameStyles.Item}";

    public int GameStyleTypeId 
        => _itemTypeGameStyle.GameStyleTypeId;

    public string GameStyleTypeName 
        => Constant.GameStyleType.Find(GameStyleTypeId).Name;

    public int Id 
        => _itemTypeGameStyle.Id;

    public int ItemTypeId 
        => _itemTypeGameStyle.ItemTypeId;

    public string ItemTypeName 
        => Constant.ItemType.Find(ItemTypeId).Name;

    string IWithName.Name 
        => GameStyleTypeName;

    int IWithValue<int>.Value 
        => GameStyleTypeId;
}
