#nullable disable

namespace Memorabilia.Blazor.Pages.Admin.ItemTypeGameStyles;

public partial class ViewItemTypeGameStyles : ComponentBase
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
    private ItemTypeGameStylesViewModel ViewModel = new();

    private bool FilterFunc1(ItemTypeGameStyleViewModel viewModel) => FilterFunc(viewModel, Search);

    protected async Task OnLoad()
    {
        ViewModel = await QueryRouter.Send(new GetItemTypeGameStyles());
    }

    protected async Task ShowDeleteConfirm(int id)
    {
        var dialog = DialogService.Show<DeleteDialog>("Delete Item Type Game Style");
        var result = await dialog.Result;

        if (result.Cancelled)
            return;

        await Delete(id);
    }

    protected async Task Delete(int id)
    {
        var deletedItem = ViewModel.ItemTypeGameStyles.Single(itemTypeGameStyle => itemTypeGameStyle.Id == id);
        var viewModel = new SaveItemTypeGameStyleViewModel(deletedItem)
        {
            IsDeleted = true
        };

        await CommandRouter.Send(new SaveItemTypeGameStyle(viewModel));

        ViewModel.ItemTypeGameStyles.Remove(deletedItem);

        Snackbar.Add($"{ViewModel.ItemTitle} was deleted successfully!", Severity.Success);
    }

    private static bool FilterFunc(ItemTypeGameStyleViewModel viewModel, string search)
    {
        return search.IsNullOrEmpty() ||
               viewModel.ItemTypeName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               viewModel.GameStyleTypeName.Contains(search, StringComparison.OrdinalIgnoreCase);
    }
}
