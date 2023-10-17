namespace Memorabilia.Blazor.Pages.Dashboard;

public partial class ViewDashboard
{
    [Inject]
    public IMediator Mediator { get; set; }

    protected DashboardModel Model 
        = new();

    protected override async Task OnInitializedAsync()
    {
        Model = await Mediator.Send(new GetDashboard());
    }

    private static Type GetComponent(DashboardItem dashboardItem)
        => Type.GetType($"Memorabilia.Blazor.Pages.Dashboard.Items.{dashboardItem}");

    private Dictionary<string, object> GetParameters(DashboardItem dashboardItem)
        => new()
            {
                { "DashboardItem", dashboardItem }
            };
}
