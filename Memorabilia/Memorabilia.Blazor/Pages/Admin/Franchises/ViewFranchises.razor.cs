#nullable disable

namespace Memorabilia.Blazor.Pages.Admin.Franchises;

public partial class ViewFranchises : ComponentBase
{
    [Inject]
    public CommandRouter CommandRouter { get; set; }

    [Inject]
    public IDialogService DialogService { get; set; }

    [Inject]
    public QueryRouter QueryRouter { get; set; }

    [Inject]
    public ISnackbar Snackbar { get; set; }

    private string Search;
    private FranchisesViewModel ViewModel = new();

    private bool FilterFunc1(FranchiseViewModel viewModel) => FilterFunc(viewModel, Search);

    protected async Task OnLoad()
    {
        ViewModel = await QueryRouter.Send(new GetFranchises.Query());
    }

    protected async Task ShowDeleteConfirm(int id)
    {
        var dialog = DialogService.Show<DeleteDialog>("Delete Franchise");
        var result = await dialog.Result;

        if (result.Cancelled)
            return;

        await Delete(id);
    }

    protected async Task Delete(int id)
    {
        var deletedItem = ViewModel.Franchises.Single(Franchise => Franchise.Id == id);
        var viewModel = new SaveFranchiseViewModel(deletedItem)
        {
            IsDeleted = true
        };

        await CommandRouter.Send(new SaveFranchise.Command(viewModel));

        ViewModel.Franchises.Remove(deletedItem);

        Snackbar.Add($"{ViewModel.ItemTitle} was deleted successfully!", Severity.Success);
    }

    private static bool FilterFunc(FranchiseViewModel viewModel, string search)
    {
        var isYear = int.TryParse(search, out var year);

        return search.IsNullOrEmpty() ||
               viewModel.SportLeagueLevelName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               viewModel.Name.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               viewModel.Location.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               (isYear && viewModel.FoundYear == year);
    }
}
