namespace Memorabilia.Blazor.Pages.User;

public partial class ManageDashboard
{
    [Inject]
    public CommandRouter CommandRouter { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Inject]
    public QueryRouter QueryRouter { get; set; }

    [Inject]
    public ISnackbar Snackbar { get; set; }

    [Parameter]
    public int UserId { get; set; }

    private string SelectAllButtonText
        => Model != null && Model.AllItemsSelected
            ? "Deselect All" 
            : "Select All";

    protected UserDashboardEditModel Model 
        = new();

    protected async Task HandleValidSubmit()
    {
        await CommandRouter.Send(new SaveUserDashboard.Command(Model));

        NavigationManager.NavigateTo(Model.ContinueNavigationPath);
        Snackbar.Add($"{Model.PageTitle} was saved successfully!", Severity.Success);
    }

    protected async Task OnLoad()
    {
        if (UserId == 0)
            NavigationManager.NavigateTo("Login");

        Entity.User user = await QueryRouter.Send(new GetUserById(UserId));

        Model 
            = new UserDashboardEditModel(new UserDashboardsModel(user.Id,
                                                                 user.DashboardItems
                                                                     .OrderBy(dashboardItem => DashboardItem.Find(dashboardItem.DashboardItemId).Name)));
    }

    protected void OnSelectAll()
    {
        bool selectAll = !Model.AllItemsSelected;

        foreach (UserDashboardModel dashboardItem in Model.UserDashboardItems)
        {
            dashboardItem.IsSelected = selectAll;
        }
    }
}
