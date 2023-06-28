namespace Memorabilia.Application.Features.Admin.ItemTypeLevel;

public class ItemTypeLevelEditModel : EditModel
{
    public ItemTypeLevelEditModel() { }

    public ItemTypeLevelEditModel(ItemTypeLevelModel model)
    {
        Id = model.Id;
        ItemType = Constant.ItemType.Find(model.ItemTypeId);
        LevelTypeId = model.LevelTypeId;
    }

    public override string ContinueNavigationPath
        => RoutePrefix;

    public override string ExitNavigationPath 
        => Constant.AdminDomainItem.ItemTypeLevels.Page;

    public string ImageFileName 
        => Constant.AdminDomainItem.ItemTypeLevels.ImageFileName;

    public override string ItemTitle 
        => Constant.AdminDomainItem.ItemTypeLevels.Item;

    public Constant.ItemType ItemType { get; set; }

    public int LevelTypeId { get; set; }

    public override string RoutePrefix 
        => Constant.AdminDomainItem.ItemTypeLevels.Page;
}
