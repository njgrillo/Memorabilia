namespace Memorabilia.Application.Features.Admin.ItemTypeSizes;

public class ItemTypeSizeModel : IWithValue<int>, IWithName
{
    private readonly Entity.ItemTypeSize _itemTypeSize;

    public ItemTypeSizeModel() { }

    public ItemTypeSizeModel(Entity.ItemTypeSize itemTypeSize)
    {
        _itemTypeSize = itemTypeSize;
    }

    public string DeleteText 
        => $"Delete {Constant.AdminDomainItem.ItemTypeSizes.Item}";

    public int Id 
        => _itemTypeSize.Id;

    public int ItemTypeId 
        => _itemTypeSize.ItemTypeId;

    public string ItemTypeName 
        => Constant.ItemType.Find(ItemTypeId).Name;

    string IWithName.Name 
        => SizeName;

    public int SizeId 
        => _itemTypeSize.SizeId;

    public string SizeName 
        => Constant.Size.Find(SizeId).Name;

    int IWithValue<int>.Value 
        => SizeId;    
}
