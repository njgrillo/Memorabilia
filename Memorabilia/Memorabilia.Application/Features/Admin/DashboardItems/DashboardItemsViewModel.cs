using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Admin.DashboardItems;

public class DashboardItemsViewModel : Model
{
    public DashboardItemsViewModel() { }

    public DashboardItemsViewModel(IEnumerable<Domain.Entities.DashboardItem> dashboardItems)
    {
        DashboardItems = dashboardItems.Select(dashboardItem => new DashboardItemViewModel(dashboardItem))
                                       .OrderBy(dashboardItem => dashboardItem.Name)
                                       .ToList();
    }

    public string AddRoute => $"{RoutePrefix}/{EditModeType.Update.Name}/0";

    public string AddTitle => $"{EditModeType.Add.Name} {ItemTitle}";

    public List<DashboardItemViewModel> DashboardItems { get; set; } = new();

    public override string ItemTitle => AdminDomainItem.DashboardItems.Item;

    public override string PageTitle => AdminDomainItem.DashboardItems.Title;

    public override string RoutePrefix => AdminDomainItem.DashboardItems.Page;
}
