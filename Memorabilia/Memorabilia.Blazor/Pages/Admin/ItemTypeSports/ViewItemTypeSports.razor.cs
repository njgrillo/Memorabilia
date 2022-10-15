#nullable disable

namespace Memorabilia.Blazor.Pages.Admin.ItemTypeSports;

public partial class ViewItemTypeSports : ComponentBase
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
    private ItemTypeSportsViewModel ViewModel = new();

    private bool FilterFunc1(ItemTypeSportViewModel viewModel) => FilterFunc(viewModel, Search);

    protected async Task OnLoad()
    {
        ViewModel = await QueryRouter.Send(new GetItemTypeSports.Query());
    }

    protected async Task ShowDeleteConfirm(int id)
    {
        var dialog = DialogService.Show<DeleteDialog>("Delete Item Type Sport");
        var result = await dialog.Result;

        if (result.Cancelled)
            return;

        await Delete(id);
    }

    private async Task Delete(int id)
    {
        var deletedItem = ViewModel.ItemTypeSports.Single(ItemTypeSport => ItemTypeSport.Id == id);
        var viewModel = new SaveItemTypeSportViewModel(deletedItem)
        {
            IsDeleted = true
        };

        await CommandRouter.Send(new SaveItemTypeSport.Command(viewModel));

        ViewModel.ItemTypeSports.Remove(deletedItem);

        Snackbar.Add($"{ViewModel.ItemTitle} was deleted successfully!", Severity.Success);
    }

    private static bool FilterFunc(ItemTypeSportViewModel viewModel, string search)
    {
        return search.IsNullOrEmpty() ||
               viewModel.ItemTypeName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               viewModel.SportName.Contains(search, StringComparison.OrdinalIgnoreCase);
    }
}
