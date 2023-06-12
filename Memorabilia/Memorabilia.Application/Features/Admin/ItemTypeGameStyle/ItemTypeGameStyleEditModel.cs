namespace Memorabilia.Application.Features.Admin.ItemTypeGameStyle;

public class ItemTypeGameStyleEditModel : EditModel
{
    public ItemTypeGameStyleEditModel() { }

    public ItemTypeGameStyleEditModel(ItemTypeGameStyleModel model)
    {
        Id = model.Id;
        ItemType = Constant.ItemType.Find(model.ItemTypeId);
        GameStyleTypeId = model.GameStyleTypeId;
    }

    public override string ExitNavigationPath 
        => Constant.AdminDomainItem.ItemTypeGameStyles.Page;

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Game Style Type is required.")]
    public int GameStyleTypeId { get; set; }

    public string ImageFileName 
        => Constant.AdminDomainItem.ItemTypeGameStyles.ImageFileName;

    public override string ItemTitle 
        => Constant.AdminDomainItem.ItemTypeGameStyles.Item;

    public Constant.ItemType ItemType { get; set; }

    public override string RoutePrefix 
        => Constant.AdminDomainItem.ItemTypeGameStyles.Page;
}
