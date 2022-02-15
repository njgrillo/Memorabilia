namespace Memorabilia.Application.Features.Admin.ItemTypeGameStyle
{
    public class ItemTypeGameStyleViewModel
    {
        private readonly Domain.Entities.ItemTypeGameStyleType _itemTypeGameStyle;

        public ItemTypeGameStyleViewModel() { }

        public ItemTypeGameStyleViewModel(Domain.Entities.ItemTypeGameStyleType itemTypeGameStyle)
        {
            _itemTypeGameStyle = itemTypeGameStyle;
        }

        public int GameStyleTypeId => _itemTypeGameStyle.GameStyleTypeId;

        public string GameStyleTypeName => Domain.Constants.GameStyleType.Find(GameStyleTypeId).Name;

        public int Id => _itemTypeGameStyle.Id;

        public int ItemTypeId => _itemTypeGameStyle.ItemTypeId;

        public string ItemTypeName => Domain.Constants.ItemType.Find(ItemTypeId).Name;
    }
}
