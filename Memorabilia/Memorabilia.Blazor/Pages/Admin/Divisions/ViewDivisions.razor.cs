#nullable disable

namespace Memorabilia.Blazor.Pages.Admin.Divisions;

public partial class ViewDivisions
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
    private DivisionsViewModel ViewModel = new();

    private bool FilterFunc1(DivisionViewModel viewModel) => FilterFunc(viewModel, Search);

    protected async Task OnLoad()
    {
        ViewModel = await QueryRouter.Send(new GetDivisions());
    }

    protected async Task ShowDeleteConfirm(int id)
    {
        var dialog = DialogService.Show<DeleteDialog>("Delete Division");
        var result = await dialog.Result;

        if (result.Cancelled)
            return;

        await Delete(id);
    }

    private async Task Delete(int id)
    {
        var deletedItem = ViewModel.Divisions.Single(Division => Division.Id == id);
        var viewModel = new SaveDivisionViewModel(deletedItem)
        {
            IsDeleted = true
        };

        await CommandRouter.Send(new SaveDivision(viewModel));

        ViewModel.Divisions.Remove(deletedItem);

        Snackbar.Add($"{ViewModel.ItemTitle} was deleted successfully!", Severity.Success);
    }

    private static bool FilterFunc(DivisionViewModel viewModel, string search)
    {
        return search.IsNullOrEmpty() ||
               viewModel.Name.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               (!viewModel.ConferenceName.IsNullOrEmpty() &&
                viewModel.ConferenceName.Contains(search, StringComparison.OrdinalIgnoreCase)) ||
               (!viewModel.LeagueName.IsNullOrEmpty() &&
                viewModel.LeagueName.Contains(search, StringComparison.OrdinalIgnoreCase)) ||
               (!viewModel.Abbreviation.IsNullOrEmpty() &&
                viewModel.Abbreviation.Contains(search, StringComparison.OrdinalIgnoreCase));
    }
}
