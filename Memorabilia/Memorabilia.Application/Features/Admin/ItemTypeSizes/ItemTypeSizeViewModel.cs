using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.ItemTypeSizes
{
    public class ItemTypeSizeViewModel 
    {
        private readonly ItemTypeSize _itemTypeSize;

        public ItemTypeSizeViewModel() { }

        public ItemTypeSizeViewModel(ItemTypeSize itemTypeSize)
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
