namespace Memorabilia.Blazor.Pages.Collection;

public partial class ViewCollections
{
    [Inject]
    public CommandRouter CommandRouter { get; set; }

    [Inject]
    public IDialogService DialogService { get; set; }

    [Inject]
    public QueryRouter QueryRouter { get; set; }

    [Inject]
    public ISnackbar Snackbar { get; set; }

    [Parameter]
    public int UserId { get; set; }

    private CollectionsViewModel _viewModel = new();

    protected async Task OnLoad()
    {
        _viewModel = await QueryRouter.Send(new GetCollections(UserId));
    }

    protected async Task ShowDeleteConfirm(int id)
    {
        var dialog = DialogService.Show<DeleteDialog>("Delete Collection");
        var result = await dialog.Result;

        if (result.Canceled)
            return;

        await Delete(id);
    }

    protected async Task Delete(int id)
    {
        var deletedItem = _viewModel.Collections.Single(collection => collection.Id == id);
        var viewModel = new SaveCollectionViewModel(deletedItem)
        {
            IsDeleted = true
        };

        await CommandRouter.Send(new SaveCollection.Command(viewModel));

        _viewModel.Collections.Remove(deletedItem);

        Snackbar.Add($"{_viewModel.ItemTitle} was deleted successfully!", Severity.Success);
    }
}
