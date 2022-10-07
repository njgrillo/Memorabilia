namespace Memorabilia.Application.Features.Admin.ItemTypeBrand;

public class ItemTypeBrandViewModel
{
    private readonly Domain.Entities.ItemTypeBrand _itemTypeBrand;

    public ItemTypeBrandViewModel() { }

    public ItemTypeBrandViewModel(Domain.Entities.ItemTypeBrand itemTypeBrand)
    {
        _itemTypeBrand = itemTypeBrand;
    }

    public int BrandId => _itemTypeBrand.BrandId;

    public string BrandName => Domain.Constants.Brand.Find(BrandId).Name;

    public int Id => _itemTypeBrand.Id;

    public int ItemTypeId => _itemTypeBrand.ItemTypeId;

    public string ItemTypeName => Domain.Constants.ItemType.Find(ItemTypeId).Name;        
}
