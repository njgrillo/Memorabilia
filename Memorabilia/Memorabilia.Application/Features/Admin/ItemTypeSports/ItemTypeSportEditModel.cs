namespace Memorabilia.Application.Features.Admin.ItemTypeSports;

public class ItemTypeSportEditModel : EditModel
{
    public ItemTypeSportEditModel() { }

    public ItemTypeSportEditModel(ItemTypeSportModel model)
    {
        Id = model.Id;
        ItemType = Constant.ItemType.Find(model.ItemTypeId);
        SportId = model.SportId;
    }

    public override string ContinueNavigationPath
        => RoutePrefix;

    public override string ExitNavigationPath 
        => Constant.AdminDomainItem.ItemTypeSports.Page;

    public string ImageFileName 
        => Constant.AdminDomainItem.ItemTypeSports.ImageFileName;

    public override string ItemTitle 
        => Constant.AdminDomainItem.ItemTypeSports.Item;

    public Constant.ItemType ItemType { get; set; }

    public override string RoutePrefix 
        => Constant.AdminDomainItem.ItemTypeSports.Page;

    public int SportId { get; set; }
}
