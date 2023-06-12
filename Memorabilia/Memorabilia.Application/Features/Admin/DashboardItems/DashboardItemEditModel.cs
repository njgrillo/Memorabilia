namespace Memorabilia.Application.Features.Admin.DashboardItems;

public class DashboardItemEditModel : EditModel
{
    public DashboardItemEditModel() { }

    public DashboardItemEditModel(DashboardItemModel model)
    {
        Description = model.Description;
        Id = model.Id;
        Name = model.Name;
    }

    [Required]
    [StringLength(500, ErrorMessage = "Description is too long.")]
    [MinLength(1, ErrorMessage = "Description is too short.")]
    public string Description { get; set; }

    public override string ExitNavigationPath 
        => Constant.AdminDomainItem.DashboardItems.Page;

    public string ImageFileName 
        => Constant.AdminDomainItem.DashboardItems.ImageFileName;

    public override string ItemTitle 
        => Constant.AdminDomainItem.DashboardItems.Item;

    [Required]
    [StringLength(100, ErrorMessage = "Name is too long.")]
    [MinLength(1, ErrorMessage = "Name is too short.")]
    public override string Name { get; set; }

    public override string RoutePrefix 
        => Constant.AdminDomainItem.DashboardItems.Page;
}


