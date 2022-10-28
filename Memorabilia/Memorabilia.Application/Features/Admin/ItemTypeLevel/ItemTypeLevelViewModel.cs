using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Admin.ItemTypeLevel;

public class ItemTypeLevelViewModel : IWithValue<int>, IWithName
{
    private readonly Domain.Entities.ItemTypeLevel _itemTypeLevel;

    public ItemTypeLevelViewModel() { }

    public ItemTypeLevelViewModel(Domain.Entities.ItemTypeLevel itemTypeLevel)
    {
        _itemTypeLevel = itemTypeLevel;
    }

    public string DeleteText => $"Delete {AdminDomainItem.ItemTypeLevels.Item}";

    public int Id => _itemTypeLevel.Id;

    public int ItemTypeId => _itemTypeLevel.ItemTypeId;

    public string ItemTypeName => ItemType.Find(ItemTypeId).Name;

    public int LevelTypeId => _itemTypeLevel.LevelTypeId;

    public string LevelTypeName => LevelType.Find(LevelTypeId).Name;

    string IWithName.Name => LevelTypeName;

    int IWithValue<int>.Value => LevelTypeId;    
}
