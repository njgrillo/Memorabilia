namespace Memorabilia.Blazor.Controls;

public partial class DomainTable
{
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

    private string AddRoute 
        => $"{RoutePrefix}/{EditModeType.Update.Name}/0";

    private string AddText 
        => $"{EditModeType.Add.Name} {DomainItemName}";

    private string DeleteText 
        => $"Delete {DomainItemName}";

    private string _search;

    private bool FilterFunc1(DomainModel model) 
        => FilterFunc(model, _search);

    private async Task Delete(int id)
    {
        DomainModel deletedItem = DomainEntities.Single(domainEntity => domainEntity.Id == id);

        var editModel = new DomainEditModel(deletedItem)
        {
            IsDeleted = true
        };

        DomainEntities.Remove(deletedItem);

        await OnDelete.InvokeAsync(editModel);

        Snackbar.Add($"{DomainItemName} was deleted successfully!", Severity.Success);
    }

    private static bool FilterFunc(DomainModel model, string search)
        => search.IsNullOrEmpty() ||
           model.Name.Contains(search, StringComparison.OrdinalIgnoreCase) ||
           (!model.Abbreviation.IsNullOrEmpty() &&
            model.Abbreviation.Contains(search, StringComparison.OrdinalIgnoreCase));
}
