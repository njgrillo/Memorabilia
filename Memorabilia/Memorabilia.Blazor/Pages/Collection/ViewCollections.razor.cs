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

    protected CollectionsModel Model = new();

    protected async Task OnLoad()
    {
        Domain.Entities.Collection[] collections = await QueryRouter.Send(new GetCollections(UserId));

        Model = new CollectionsModel(collections);
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
        var deletedItem = Model.Collections.Single(collection => collection.Id == id);
        var viewModel = new CollectionEditModel(deletedItem)
        {
            IsDeleted = true
        };

        await CommandRouter.Send(new SaveCollection.Command(viewModel));

        Model.Collections.Remove(deletedItem);

        Snackbar.Add($"{Model.ItemTitle} was deleted successfully!", Severity.Success);
    }
}
