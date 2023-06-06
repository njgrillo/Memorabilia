using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Admin.ItemTypeGameStyle;

public class ItemTypeGameStyleViewModel : IWithValue<int>, IWithName
{
    private readonly Entity.ItemTypeGameStyleType _itemTypeGameStyle;

    public ItemTypeGameStyleViewModel() { }

    public ItemTypeGameStyleViewModel(Entity.ItemTypeGameStyleType itemTypeGameStyle)
    {
        _itemTypeGameStyle = itemTypeGameStyle;
    }

    public string DeleteText => $"Delete {AdminDomainItem.ItemTypeGameStyles.Item}";

    public int GameStyleTypeId => _itemTypeGameStyle.GameStyleTypeId;

    public string GameStyleTypeName => GameStyleType.Find(GameStyleTypeId).Name;

    public int Id => _itemTypeGameStyle.Id;

    public int ItemTypeId => _itemTypeGameStyle.ItemTypeId;

    public string ItemTypeName => ItemType.Find(ItemTypeId).Name;

    string IWithName.Name => GameStyleTypeName;

    int IWithValue<int>.Value => GameStyleTypeId;
}
