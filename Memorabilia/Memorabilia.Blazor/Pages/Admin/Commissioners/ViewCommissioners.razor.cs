#nullable disable

namespace Memorabilia.Blazor.Pages.Admin.Commissioners;

public partial class ViewCommissioners
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
    private CommissionersViewModel ViewModel = new();

    private bool FilterFunc1(CommissionerViewModel viewModel) => FilterFunc(viewModel, Search);

    protected async Task OnLoad()
    {
        ViewModel = await QueryRouter.Send(new GetCommissioners());
    }

    protected async Task ShowDeleteConfirm(int id)
    {
        var dialog = DialogService.Show<DeleteDialog>("Delete Commissioner");
        var result = await dialog.Result;

        if (result.Cancelled)
            return;

        await Delete(id);
    }

    private async Task Delete(int id)
    {
        var deletedItem = ViewModel.Commissioners.Single(Commissioner => Commissioner.Id == id);
        var viewModel = new SaveCommissionerViewModel(deletedItem)
        {
            IsDeleted = true
        };

        await CommandRouter.Send(new SaveCommissioner(viewModel));

        ViewModel.Commissioners.Remove(deletedItem);

        Snackbar.Add($"{ViewModel.ItemTitle} was deleted successfully!", Severity.Success);
    }

    private static bool FilterFunc(CommissionerViewModel viewModel, string search)
    {
        var isYear = int.TryParse(search, out var year);

        return search.IsNullOrEmpty() ||
               viewModel.SportLeagueLevelName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               (isYear && viewModel?.BeginYear == year) ||
               (isYear && viewModel?.EndYear == year) ||
               (viewModel.Person != null &&
                viewModel.Person.DisplayName.Contains(search, StringComparison.OrdinalIgnoreCase));
    }
}
