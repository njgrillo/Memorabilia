namespace Memorabilia.Application.Features.Admin.ItemTypeBrand;

public class ItemTypeBrandEditModel : EditModel
{
    public ItemTypeBrandEditModel() { }

    public ItemTypeBrandEditModel(ItemTypeBrandModel model)
    {
        Id = model.Id;
        ItemType = Constant.ItemType.Find(model.ItemTypeId);
        Brand = Constant.Brand.Find(model.BrandId);
    }

    public Constant.Brand Brand { get; set; }

    public override string ContinueNavigationPath
        => RoutePrefix;

    public override string ExitNavigationPath 
        => Constant.AdminDomainItem.ItemTypeBrands.Page;

    public string ImageFileName 
        => Constant.AdminDomainItem.ItemTypeBrands.ImageFileName;

    public override string ItemTitle 
        => Constant.AdminDomainItem.ItemTypeBrands.Item;

    public Constant.ItemType ItemType { get; set; }     

    public override string RoutePrefix 
        => Constant.AdminDomainItem.ItemTypeBrands.Page;
}
