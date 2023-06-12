namespace Memorabilia.Application.Features.Admin.DashboardItems;

public class DashboardItemModel
{
    private readonly Entity.DashboardItem _dashboardItem;

    public DashboardItemModel() { }

    public DashboardItemModel(Entity.DashboardItem dashboardItem)
    {
        _dashboardItem = dashboardItem;
    }

    public string Description 
        => _dashboardItem.Description;

    public int Id 
        => _dashboardItem.Id;

    public string Name 
        => _dashboardItem.Name;
}
