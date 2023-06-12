namespace Memorabilia.Application.Features.Admin.ItemTypeSizes;

public class ItemTypeSizeEditModel : EditModel
{
    public ItemTypeSizeEditModel() { }

    public ItemTypeSizeEditModel(ItemTypeSizeModel viewModel)
    {
        Id = viewModel.Id;
        ItemType = Constant.ItemType.Find(viewModel.ItemTypeId);
        Size = Constant.Size.Find(viewModel.SizeId);
    }

    public override string ExitNavigationPath 
        => Constant.AdminDomainItem.ItemTypeSizes.Page;

    public string ImageFileName 
        => Constant.AdminDomainItem.ItemTypeSizes.ImageFileName;

    public override string ItemTitle 
        => Constant.AdminDomainItem.ItemTypeSizes.Item;

    public Constant.ItemType ItemType { get; set; }

    public override string RoutePrefix 
        => Constant.AdminDomainItem.ItemTypeSizes.Page;

    public Constant.Size Size { get; set; }
}
