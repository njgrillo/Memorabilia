namespace Memorabilia.Application.Features.Admin.ItemTypeSport
{
    public class ItemTypeSportViewModel
    {
        private readonly Domain.Entities.ItemTypeSport _itemTypeSport;

        public ItemTypeSportViewModel() { }

        public ItemTypeSportViewModel(Domain.Entities.ItemTypeSport itemTypeSport)
        {
            _itemTypeSport = itemTypeSport;
        }

        public int Id => _itemTypeSport.Id;

        public int ItemTypeId => _itemTypeSport.ItemTypeId;

        public string ItemTypeName => Domain.Constants.ItemType.Find(ItemTypeId).Name;

        public int SportId => _itemTypeSport.SportId;

        public string SportName => Domain.Constants.Sport.Find(SportId).Name;
    }
}
