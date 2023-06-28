namespace Memorabilia.Blazor.Pages.User;

public partial class ManageDashboard
{
    [Inject]
    public IApplicationStateService ApplicationStateService { get; set; }

    [Inject]
    public CommandRouter CommandRouter { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Inject]
    public ISnackbar Snackbar { get; set; }

    private string SelectAllButtonText
        => Model != null && Model.AllItemsSelected
            ? "Deselect All" 
            : "Select All";

    protected UserDashboardEditModel Model 
        = new();    

    protected override void OnInitialized()
    {
        Model 
            = new UserDashboardEditModel(new UserDashboardsModel(ApplicationStateService.CurrentUser.Id,
                                                                 ApplicationStateService.CurrentUser.DashboardItems.OrderBy(dashboardItem => DashboardItem.Find(dashboardItem.DashboardItemId).Name)));
    }

    protected void OnSelectAll()
    {
        bool selectAll = !Model.AllItemsSelected;

        foreach (UserDashboardModel dashboardItem in Model.UserDashboardItems)
        {
            dashboardItem.IsSelected = selectAll;
        }
    }

    protected async Task Save()
    {
        await CommandRouter.Send(new SaveUserDashboard.Command(Model));

        NavigationManager.NavigateTo(Model.ContinueNavigationPath);
        Snackbar.Add($"{Model.PageTitle} was saved successfully!", Severity.Success);
    }
}
