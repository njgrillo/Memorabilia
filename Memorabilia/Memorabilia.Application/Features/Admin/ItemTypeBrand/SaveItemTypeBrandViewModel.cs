using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Admin.ItemTypeBrand;

public class SaveItemTypeBrandViewModel : SaveViewModel
{
    public SaveItemTypeBrandViewModel() { }

    public SaveItemTypeBrandViewModel(ItemTypeBrandViewModel viewModel)
    {
        Id = viewModel.Id;
        ItemTypeId = viewModel.ItemTypeId;
        BrandId = viewModel.BrandId;
    }

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Brand is required.")]
    public int BrandId { get; set; }

    public Brand[] Brands => Brand.All;

    public override string ExitNavigationPath => AdminDomainItem.ItemTypeBrands.Page;

    public string ImageFileName => AdminDomainItem.ItemTypeBrands.ImageFileName;

    public override string ItemTitle => AdminDomainItem.ItemTypeBrands.Item;

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Item Type is required.")]
    public int ItemTypeId { get; set; }      
    
    public ItemType[] ItemTypes => ItemType.All;

    public override string RoutePrefix => AdminDomainItem.ItemTypeBrands.Page;
}
