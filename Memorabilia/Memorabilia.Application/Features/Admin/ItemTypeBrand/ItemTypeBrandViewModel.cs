using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Admin.ItemTypeBrand;

public class ItemTypeBrandViewModel : IWithValue<int>, IWithName
{
    private readonly Domain.Entities.ItemTypeBrand _itemTypeBrand;

    public ItemTypeBrandViewModel() { }

    public ItemTypeBrandViewModel(Domain.Entities.ItemTypeBrand itemTypeBrand)
    {
        _itemTypeBrand = itemTypeBrand;
    }

    public int BrandId => _itemTypeBrand.BrandId;

    public string BrandName => Brand.Find(BrandId).Name;

    public string DeleteText => $"Delete {AdminDomainItem.ItemTypeBrands.Item}"; 

    public int Id => _itemTypeBrand.Id;    

    public int ItemTypeId => _itemTypeBrand.ItemTypeId;

    public string ItemTypeName => ItemType.Find(ItemTypeId).Name;

    string IWithName.Name => BrandName;

    int IWithValue<int>.Value => BrandId;
}
