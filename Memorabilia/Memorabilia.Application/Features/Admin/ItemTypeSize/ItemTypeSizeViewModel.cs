namespace Memorabilia.Application.Features.Admin.ItemTypeSize
{
    public class ItemTypeSizeViewModel 
    {
        private readonly Domain.Entities.ItemTypeSize _itemTypeSize;

        public ItemTypeSizeViewModel() { }

        public ItemTypeSizeViewModel(Domain.Entities.ItemTypeSize itemTypeSize)
        {
            _itemTypeSize = itemTypeSize;
        }

        public int Id => _itemTypeSize.Id;

        public int ItemTypeId => _itemTypeSize.ItemTypeId;

        public string ItemTypeName => Domain.Constants.ItemType.Find(ItemTypeId).Name;

        public int SizeId => _itemTypeSize.SizeId;

        public string SizeName => Domain.Constants.Size.Find(SizeId).Name;
    }
}
