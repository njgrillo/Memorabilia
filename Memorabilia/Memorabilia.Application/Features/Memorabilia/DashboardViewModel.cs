namespace Memorabilia.Application.Features.Memorabilia;

public class DashboardViewModel : ViewModel
{
    public DashboardViewModel() { }

    public DashboardViewModel(IEnumerable<DashboardItemViewModel> dashboardItemViewModels)
    {
        UserDashboardItems = dashboardItemViewModels;
    }        

    public override string PageTitle => "Dashboard";

    public IEnumerable<DashboardItemViewModel> UserDashboardItems { get; set; }
}
