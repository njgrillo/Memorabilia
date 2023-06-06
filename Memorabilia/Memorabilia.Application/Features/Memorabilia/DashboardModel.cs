namespace Memorabilia.Application.Features.Memorabilia;

public class DashboardModel : Model
{
    public DashboardModel() { }

    public DashboardModel(IEnumerable<DashboardItemModel> dashboardItemViewModels)
    {
        UserDashboardItems = dashboardItemViewModels;
    }        

    public override string PageTitle => "Dashboard";

    public IEnumerable<DashboardItemModel> UserDashboardItems { get; set; }
}
