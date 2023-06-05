namespace Memorabilia.Application.Features.Memorabilia;

public class DashboardModel : ViewModel
{
    public DashboardModel() { }

    public DashboardModel(IEnumerable<DashboardItemViewModel> dashboardItemViewModels)
    {
        UserDashboardItems = dashboardItemViewModels;
    }        

    public override string PageTitle => "Dashboard";

    public IEnumerable<DashboardItemViewModel> UserDashboardItems { get; set; }
}
