namespace Memorabilia.Application.Features.Admin.ItemTypeSports;

public class ItemTypeSportEditModel : EditModel
{
    public ItemTypeSportEditModel() { }

    public ItemTypeSportEditModel(ItemTypeSportModel viewModel)
    {
        Id = viewModel.Id;
        ItemType = Constant.ItemType.Find(viewModel.ItemTypeId);
        SportId = viewModel.SportId;
    }

    public override string ExitNavigationPath 
        => Constant.AdminDomainItem.ItemTypeSports.Page;

    public string ImageFileName 
        => Constant.AdminDomainItem.ItemTypeSports.ImageFileName;

    public override string ItemTitle 
        => Constant.AdminDomainItem.ItemTypeSports.Item;

    public Constant.ItemType ItemType { get; set; }

    public override string RoutePrefix 
        => Constant.AdminDomainItem.ItemTypeSports.Page;

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Sport is required.")]
    public int SportId { get; set; }
}
