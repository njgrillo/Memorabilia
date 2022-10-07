using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Admin.ItemTypeSizes;

public class SaveItemTypeSizeViewModel : SaveViewModel
{
    public SaveItemTypeSizeViewModel() { }

    public SaveItemTypeSizeViewModel(ItemTypeSizeViewModel viewModel)
    {
        Id = viewModel.Id;
        ItemTypeId = viewModel.ItemTypeId;
        SizeId = viewModel.SizeId;
    }

    public override string ExitNavigationPath => AdminDomainItem.ItemTypeSizes.Page;

    public string ImagePath => AdminDomainItem.ItemTypeSizes.ImagePath;

    public override string ItemTitle => AdminDomainItem.ItemTypeSizes.Item;

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Item Type is required.")]
    public int ItemTypeId { get; set; }

    public ItemType[] ItemTypes => ItemType.All;

    public override string RoutePrefix => AdminDomainItem.ItemTypeSizes.Page;

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Size is required.")]
    public int SizeId { get; set; }

    public Size[] Sizes => Size.All;
}
