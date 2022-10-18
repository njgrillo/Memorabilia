#nullable disable

namespace Memorabilia.Blazor.Pages.Admin.ItemTypeBrands;

public partial class ViewItemTypeBrands : ComponentBase
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
    private ItemTypeBrandsViewModel ViewModel = new();

    private bool FilterFunc1(ItemTypeBrandViewModel viewModel) => FilterFunc(viewModel, Search);

    protected async Task OnLoad()
    {
        ViewModel = await QueryRouter.Send(new GetItemTypeBrands());
    }

    protected async Task ShowDeleteConfirm(int id)
    {
        var dialog = DialogService.Show<DeleteDialog>("Delete Item Type Brand");
        var result = await dialog.Result;

        if (result.Cancelled)
            return;

        await Delete(id);
    }

    private async Task Delete(int id)
    {
        var deletedItem = ViewModel.ItemTypeBrands.Single(ItemTypeBrand => ItemTypeBrand.Id == id);
        var viewModel = new SaveItemTypeBrandViewModel(deletedItem)
        {
            IsDeleted = true
        };

        await CommandRouter.Send(new SaveItemTypeBrand(viewModel));

        ViewModel.ItemTypeBrands.Remove(deletedItem);

        Snackbar.Add($"{ViewModel.ItemTitle} was deleted successfully!", Severity.Success);
    }

    private static bool FilterFunc(ItemTypeBrandViewModel viewModel, string search)
    {
        return search.IsNullOrEmpty() ||
               viewModel.ItemTypeName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               viewModel.BrandName.Contains(search, StringComparison.OrdinalIgnoreCase);
    }
}
