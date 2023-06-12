namespace Memorabilia.Blazor.Pages.User;

public partial class ManageDashboard : ComponentBase
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
        => _viewModel != null && _viewModel.AllItemsSelected
            ? "Deselect All" 
            : "Select All";

    private UserDashboardEditModel _viewModel 
        = new();

    protected async Task HandleValidSubmit()
    {
        await CommandRouter.Send(new SaveUserDashboard.Command(_viewModel));

        NavigationManager.NavigateTo(_viewModel.ContinueNavigationPath);
        Snackbar.Add($"{_viewModel.PageTitle} was saved successfully!", Severity.Success);
    }

    protected async Task OnLoad()
    {
        if (UserId == 0)
            NavigationManager.NavigateTo("Login");

        Entity.User user = await QueryRouter.Send(new GetUserById(UserId));

        _viewModel 
            = new UserDashboardEditModel(new UserDashboardsModel(user.Id,
                                                                 user.DashboardItems
                                                                     .OrderBy(dashboardItem => DashboardItem.Find(dashboardItem.DashboardItemId).Name)));
    }

    protected void OnSelectAll()
    {
        bool selectAll = !_viewModel.AllItemsSelected;

        foreach (UserDashboardModel dashboardItem in _viewModel.UserDashboardItems)
        {
            dashboardItem.IsSelected = selectAll;
        }
    }
}
