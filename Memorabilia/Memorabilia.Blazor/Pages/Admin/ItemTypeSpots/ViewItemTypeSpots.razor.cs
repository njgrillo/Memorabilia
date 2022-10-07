#nullable disable

namespace Memorabilia.Blazor.Pages.Admin.ItemTypeSpots;

public partial class ViewItemTypeSpots : ComponentBase
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
    private ItemTypeSpotsViewModel ViewModel = new();

    private bool FilterFunc1(ItemTypeSpotViewModel viewModel) => FilterFunc(viewModel, Search);

    protected async Task OnLoad()
    {
        ViewModel = await QueryRouter.Send(new GetItemTypeSpots.Query()).ConfigureAwait(false);
    }

    protected async Task ShowDeleteConfirm(int id)
    {
        var dialog = DialogService.Show<DeleteDialog>("Delete Item Type Spot");
        var result = await dialog.Result;

        if (result.Cancelled)
            return;

        await Delete(id).ConfigureAwait(false);
    }

    private async Task Delete(int id)
    {
        var deletedItem = ViewModel.ItemTypeSpots.Single(ItemTypeSpot => ItemTypeSpot.Id == id);
        var viewModel = new SaveItemTypeSpotViewModel(deletedItem)
        {
            IsDeleted = true
        };

        await CommandRouter.Send(new SaveItemTypeSpot.Command(viewModel)).ConfigureAwait(false);

        ViewModel.ItemTypeSpots.Remove(deletedItem);

        Snackbar.Add($"{ViewModel.ItemTitle} was deleted successfully!", Severity.Success);
    }

    private static bool FilterFunc(ItemTypeSpotViewModel viewModel, string search)
    {
        return search.IsNullOrEmpty() ||
               viewModel.ItemTypeName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               viewModel.SpotName.Contains(search, StringComparison.OrdinalIgnoreCase);
    }
}
