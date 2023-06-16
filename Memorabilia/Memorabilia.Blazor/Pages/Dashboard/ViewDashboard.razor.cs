namespace Memorabilia.Blazor.Pages.Dashboard;

public partial class ViewDashboard
{
    [Inject]
    public QueryRouter QueryRouter { get; set; }

    protected DashboardModel Model 
        = new();

    protected override async Task OnInitializedAsync()
    {
        Model = await QueryRouter.Send(new GetDashboard());
    }

    private static Type GetComponent(DashboardItem dashboardItem)
        => Type.GetType($"Memorabilia.Blazor.Pages.Dashboard.Items.{dashboardItem}");

    private Dictionary<string, object> GetParameters(DashboardItem dashboardItem)
        => new()
            {
                { "DashboardItem", dashboardItem }
            };
}
