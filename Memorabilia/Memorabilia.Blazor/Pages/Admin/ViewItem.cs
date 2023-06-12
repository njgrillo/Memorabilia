namespace Memorabilia.Blazor.Pages.Admin;

public abstract class ViewItem<TModel, TItemModel> : CommandQuery
{
    [Inject]
    public IDialogService DialogService { get; set; }

    [Inject]
    public ISnackbar Snackbar { get; set; }

    protected string Search;

    protected TModel Model 
        = (TModel)Activator.CreateInstance(typeof(TModel));

    protected bool FilterFunc1(TItemModel model) 
        => FilterFunc(model, Search);

    protected abstract Task Delete(int id);

    protected abstract bool FilterFunc(TItemModel model, string search);

    protected async Task OnLoad(IQuery<TModel> request)
    {
        Model = await QueryRouter.Send(request);
    }

    protected async Task Save(ICommand command)
    {
        await CommandRouter.Send(command);
    }

    protected virtual async Task ShowDeleteConfirm(int id, string text)
    {
        var dialog = DialogService.Show<DeleteDialog>(text);
        var result = await dialog.Result;

        if (result.Canceled)
            return;

        await Delete(id);
    }

    protected void ShowDeleteSuccessfulMessage(string itemTitle)
    {
        Snackbar.Add($"{itemTitle} was deleted successfully!", Severity.Success);
    }
}
