namespace Memorabilia.Application.Features.Admin.ItemTypeLevel
{
    public class ItemTypeLevelViewModel
    {
        private readonly Domain.Entities.ItemTypeLevel _itemTypeLevel;

        public ItemTypeLevelViewModel() { }

        public ItemTypeLevelViewModel(Domain.Entities.ItemTypeLevel itemTypeLevel)
        {
            _itemTypeLevel = itemTypeLevel;
        }        

        public int Id => _itemTypeLevel.Id;

        public int ItemTypeId => _itemTypeLevel.ItemTypeId;

        public string ItemTypeName => Domain.Constants.ItemType.Find(ItemTypeId).Name;

        public int LevelTypeId => _itemTypeLevel.LevelTypeId;

        public string LevelTypeName => Domain.Constants.LevelType.Find(LevelTypeId).Name;
    }
}
