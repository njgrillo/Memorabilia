#nullable disable

namespace Memorabilia.Blazor.Pages.Admin;

public abstract class ViewItem<TViewModel, TItemViewModel> : ImagePage
{
    [Inject]
    public IDialogService DialogService { get; set; }

    [Inject]
    public ISnackbar Snackbar { get; set; }

    protected string Search;
    protected TViewModel ViewModel = (TViewModel)Activator.CreateInstance(typeof(TViewModel));

    protected bool FilterFunc1(TItemViewModel viewModel) => FilterFunc(viewModel, Search);

    protected abstract Task Delete(int id);

    protected abstract bool FilterFunc(TItemViewModel viewModel, string search);

    protected async Task OnLoad(IQuery<TViewModel> request)
    {
        ViewModel = await QueryRouter.Send(request);
    }

    protected async Task Save(ICommand command)
    {
        await CommandRouter.Send(command);
    }

    protected virtual async Task ShowDeleteConfirm(int id, string text)
    {
        var dialog = DialogService.Show<DeleteDialog>(text);
        var result = await dialog.Result;

        if (result.Cancelled)
            return;

        await Delete(id);
    }

    protected void ShowDeleteSuccessfulMessage(string itemTitle)
    {
        Snackbar.Add($"{itemTitle} was deleted successfully!", Severity.Success);
    }
}
