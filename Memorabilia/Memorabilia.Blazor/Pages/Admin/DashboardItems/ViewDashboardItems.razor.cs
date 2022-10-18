#nullable disable

using DashboardItemViewModel = Memorabilia.Application.Features.Admin.DashboardItems.DashboardItemViewModel;

namespace Memorabilia.Blazor.Pages.Admin.DashboardItems;

public partial class ViewDashboardItems
{
    [Inject]
    public CommandRouter CommandRouter { get; set; }

    [Inject]
    public IDialogService DialogService { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Inject]
    public QueryRouter QueryRouter { get; set; }

    [Inject]
    public ISnackbar Snackbar { get; set; }

    private string Search;
    private DashboardItemsViewModel ViewModel = new();

    private bool FilterFunc1(DashboardItemViewModel viewModel) => FilterFunc(viewModel, Search);

    protected async Task OnLoad()
    {
        ViewModel = await QueryRouter.Send(new GetDashboardItems());
    }

    protected async Task ShowDeleteConfirm(int id)
    {
        var dialog = DialogService.Show<DeleteDialog>("Delete Dashboard Item");
        var result = await dialog.Result;

        if (result.Cancelled)
            return;

        await Delete(id);
    }

    protected async Task Delete(int id)
    {
        var deletedItem = ViewModel.DashboardItems.Single(dashboardItem => dashboardItem.Id == id);
        var viewModel = new SaveDashboardItemViewModel(deletedItem)
        {
            IsDeleted = true
        };

        await CommandRouter.Send(new SaveDashboardItem(viewModel));

        ViewModel.DashboardItems.Remove(deletedItem);

        Snackbar.Add($"{ViewModel.ItemTitle} was deleted successfully!", Severity.Success);
    }

    private static bool FilterFunc(DashboardItemViewModel viewModel, string search)
    {
        return search.IsNullOrEmpty() ||
               viewModel.Name.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               viewModel.Description.Contains(search, StringComparison.OrdinalIgnoreCase);
    }
}
