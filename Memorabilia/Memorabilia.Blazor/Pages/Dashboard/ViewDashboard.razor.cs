namespace Memorabilia.Blazor.Pages.Dashboard;

public partial class ViewDashboard
{
    [Inject]
    public QueryRouter QueryRouter { get; set; }

    [Parameter]
    public int UserId { get; set; }

    protected DashboardModel Model 
        = new();

    protected async Task OnLoad()
    {
        Model = await QueryRouter.Send(new GetDashboard(UserId));
    }

    private static Type GetComponent(DashboardItem dashboardItem)
        => Type.GetType($"Memorabilia.Blazor.Pages.Dashboard.Items.{dashboardItem}");

    private Dictionary<string, object> GetParameters(DashboardItem dashboardItem)
        => new Dictionary<string, object>
            {
                { "DashboardItem", dashboardItem },
                { "UserId", UserId }
            };
}
