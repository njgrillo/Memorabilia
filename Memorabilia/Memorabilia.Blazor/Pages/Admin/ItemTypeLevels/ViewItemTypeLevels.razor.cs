#nullable disable

namespace Memorabilia.Blazor.Pages.Admin.ItemTypeLevels;

public partial class ViewItemTypeLevels : ComponentBase
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
    private ItemTypeLevelsViewModel ViewModel = new();

    private bool FilterFunc1(ItemTypeLevelViewModel viewModel) => FilterFunc(viewModel, Search);

    protected async Task OnLoad()
    {
        ViewModel = await QueryRouter.Send(new GetItemTypeLevels.Query());
    }

    protected async Task ShowDeleteConfirm(int id)
    {
        var dialog = DialogService.Show<DeleteDialog>("Delete Item Type Level");
        var result = await dialog.Result;

        if (result.Cancelled)
            return;

        await Delete(id);
    }

    private async Task Delete(int id)
    {
        var deletedItem = ViewModel.ItemTypeLevels.Single(ItemTypeLevel => ItemTypeLevel.Id == id);
        var viewModel = new SaveItemTypeLevelViewModel(deletedItem)
        {
            IsDeleted = true
        };

        await CommandRouter.Send(new SaveItemTypeLevel.Command(viewModel));

        ViewModel.ItemTypeLevels.Remove(deletedItem);

        Snackbar.Add($"{ViewModel.ItemTitle} was deleted successfully!", Severity.Success);
    }

    private static bool FilterFunc(ItemTypeLevelViewModel viewModel, string search)
    {
        return search.IsNullOrEmpty() ||
               viewModel.ItemTypeName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               viewModel.LevelTypeName.Contains(search, StringComparison.OrdinalIgnoreCase);
    }
}
