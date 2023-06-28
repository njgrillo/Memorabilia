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

    public override string ContinueNavigationPath
        => RoutePrefix;

    public string Description { get; set; }

    public override string ExitNavigationPath 
        => Constant.AdminDomainItem.DashboardItems.Page;

    public string ImageFileName 
        => Constant.AdminDomainItem.DashboardItems.ImageFileName;

    public override string ItemTitle 
        => Constant.AdminDomainItem.DashboardItems.Item;

    public override string Name { get; set; }

    public override string RoutePrefix 
        => Constant.AdminDomainItem.DashboardItems.Page;
}


