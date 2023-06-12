namespace Memorabilia.Application.Features.Admin.ItemTypeBrand;

public class ItemTypeBrandModel : IWithValue<int>, IWithName
{
    private readonly Entity.ItemTypeBrand _itemTypeBrand;

    public ItemTypeBrandModel() { }

    public ItemTypeBrandModel(Entity.ItemTypeBrand itemTypeBrand)
    {
        _itemTypeBrand = itemTypeBrand;
    }

    public int BrandId 
        => _itemTypeBrand.BrandId;

    public string BrandName 
        => Constant.Brand.Find(BrandId).Name;

    public string DeleteText 
        => $"Delete {Constant.AdminDomainItem.ItemTypeBrands.Item}"; 

    public int Id 
        => _itemTypeBrand.Id;    

    public int ItemTypeId 
        => _itemTypeBrand.ItemTypeId;

    public string ItemTypeName 
        => Constant.ItemType.Find(ItemTypeId).Name;

    string IWithName.Name 
        => BrandName;

    int IWithValue<int>.Value 
        => BrandId;
}
