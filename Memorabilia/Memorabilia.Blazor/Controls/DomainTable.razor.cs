namespace Memorabilia.Blazor.Controls;

public partial class DomainTable : ComponentBase
{
    [Inject]
    public IDialogService DialogService { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Inject]
    public ISnackbar Snackbar { get; set; }

    [Parameter]
    public List<DomainModel> DomainEntities { get; set; }

    [Parameter]
    public string DomainItemName { get; set; }

    [Parameter]
    public string DomainItemTitle { get; set; }

    [Parameter]
    public EventCallback<DomainEditModel> OnDelete { get; set; }

    [Parameter]
    public string RoutePrefix { get; set; }

    private string AddRoute => $"{RoutePrefix}/{EditModeType.Update.Name}/0";

    private string AddText => $"{EditModeType.Add.Name} {DomainItemName}";

    private string DeleteText => $"Delete {DomainItemName}";

    private string _search;

    private bool FilterFunc1(DomainModel domainViewModel) => FilterFunc(domainViewModel, _search);

    protected async Task ShowDeleteConfirm(int id)
    {
        var dialog = DialogService.Show<DeleteDialog>(DeleteText);
        var result = await dialog.Result;

        if (result.Canceled)
            return;

        await Delete(id);
    }

    private async Task Delete(int id)
    {
        var deletedItem = DomainEntities.Single(domainEntity => domainEntity.Id == id);
        var viewModel = new DomainEditModel(deletedItem)
        {
            IsDeleted = true
        };

        DomainEntities.Remove(deletedItem);

        await OnDelete.InvokeAsync(viewModel);

        Snackbar.Add($"{DomainItemName} was deleted successfully!", Severity.Success);
    }

    private static bool FilterFunc(DomainModel domainViewModel, string search)
    {
        return search.IsNullOrEmpty() ||
               domainViewModel.Name.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               (!domainViewModel.Abbreviation.IsNullOrEmpty() &&
                domainViewModel.Abbreviation.Contains(search, StringComparison.OrdinalIgnoreCase));
    }
}
