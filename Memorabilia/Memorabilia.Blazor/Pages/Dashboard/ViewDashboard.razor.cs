namespace Memorabilia.Blazor.Pages.Dashboard;

public partial class ViewDashboard
{
    [Inject]
    public QueryRouter QueryRouter { get; set; }

    [Parameter]
    public int UserId { get; set; }

    private DashboardModel _viewModel = new();

    protected async Task OnLoad()
    {
        _viewModel = await QueryRouter.Send(new GetDashboard(UserId));
    }

    private static Type GetComponent(DashboardItem dashboardItem)
    {
        return Type.GetType($"Memorabilia.Blazor.Pages.Dashboard.Items.{dashboardItem}");
    }

    private Dictionary<string, object> GetParameters(DashboardItem dashboardItem)
    {
        return new Dictionary<string, object>
        {
            { "DashboardItem", dashboardItem },
            { "UserId", UserId }
        };
    }
}
