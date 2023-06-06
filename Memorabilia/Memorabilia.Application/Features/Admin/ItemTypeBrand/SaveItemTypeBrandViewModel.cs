using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Admin.ItemTypeBrand;

public class SaveItemTypeBrandViewModel : EditModel
{
    public SaveItemTypeBrandViewModel() { }

    public SaveItemTypeBrandViewModel(ItemTypeBrandViewModel viewModel)
    {
        Id = viewModel.Id;
        ItemType = ItemType.Find(viewModel.ItemTypeId);
        Brand = Brand.Find(viewModel.BrandId);
    }

    public Brand Brand { get; set; }

    public override string ExitNavigationPath => AdminDomainItem.ItemTypeBrands.Page;

    public string ImageFileName => AdminDomainItem.ItemTypeBrands.ImageFileName;

    public override string ItemTitle => AdminDomainItem.ItemTypeBrands.Item;

    public ItemType ItemType { get; set; }     

    public override string RoutePrefix => AdminDomainItem.ItemTypeBrands.Page;
}
