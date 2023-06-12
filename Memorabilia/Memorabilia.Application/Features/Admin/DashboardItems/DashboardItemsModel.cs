namespace Memorabilia.Application.Features.Admin.DashboardItems;

public class DashboardItemsModel : Model
{
    public DashboardItemsModel() { }

    public DashboardItemsModel(IEnumerable<Entity.DashboardItem> dashboardItems)
    {
        DashboardItems = dashboardItems.Select(dashboardItem => new DashboardItemModel(dashboardItem))
                                       .OrderBy(dashboardItem => dashboardItem.Name)
                                       .ToList();
    }

    public string AddRoute 
        => $"{RoutePrefix}/{Constant.EditModeType.Update.Name}/0";

    public string AddTitle 
        => $"{Constant.EditModeType.Add.Name} {ItemTitle}";

    public List<DashboardItemModel> DashboardItems { get; set; } 
        = new();

    public override string ItemTitle 
        => Constant.AdminDomainItem.DashboardItems.Item;

    public override string PageTitle 
        => Constant.AdminDomainItem.DashboardItems.Title;

    public override string RoutePrefix 
        => Constant.AdminDomainItem.DashboardItems.Page;
}
