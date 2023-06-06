using Memorabilia.Domain.Constants;
using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.ItemTypeSizes;


public class ItemTypeSizeViewModel : IWithValue<int>, IWithName
{
    private readonly ItemTypeSize _itemTypeSize;

    public ItemTypeSizeViewModel() { }

    public ItemTypeSizeViewModel(ItemTypeSize itemTypeSize)
    {
        _itemTypeSize = itemTypeSize;
    }

    public string DeleteText => $"Delete {AdminDomainItem.ItemTypeSizes.Item}";

    public int Id => _itemTypeSize.Id;

    public int ItemTypeId => _itemTypeSize.ItemTypeId;

    public string ItemTypeName => Constant.ItemType.Find(ItemTypeId).Name;

    string IWithName.Name => SizeName;

    public int SizeId => _itemTypeSize.SizeId;

    public string SizeName => Constant.Size.Find(SizeId).Name;

    int IWithValue<int>.Value => SizeId;    
}
