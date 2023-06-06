using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Admin.ItemTypeSizes;

public class SaveItemTypeSizeViewModel : EditModel
{
    public SaveItemTypeSizeViewModel() { }

    public SaveItemTypeSizeViewModel(ItemTypeSizeViewModel viewModel)
    {
        Id = viewModel.Id;
        ItemType = ItemType.Find(viewModel.ItemTypeId);
        Size = Size.Find(viewModel.SizeId);
    }

    public override string ExitNavigationPath => AdminDomainItem.ItemTypeSizes.Page;

    public string ImageFileName => AdminDomainItem.ItemTypeSizes.ImageFileName;

    public override string ItemTitle => AdminDomainItem.ItemTypeSizes.Item;

    public ItemType ItemType { get; set; }

    public override string RoutePrefix => AdminDomainItem.ItemTypeSizes.Page;

    public Size Size { get; set; }
}
