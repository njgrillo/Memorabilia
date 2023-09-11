namespace Memorabilia.Blazor.Pages.MemorabiliaItems;

public partial class ViewMemorabilia
{
    [Inject]
    public NavigationManager NavigationManager { get; set; }

    protected bool IsDetailView 
        = true;

    protected MemorabiliasModel Model
        = new();

    protected bool ReloadGrid { get; set; }

    private MemorabiliaSearchCriteria _filter 
        = new();

    protected void AddMemorabilia()
    {
        NavigationManager.NavigateTo($"{NavigationPath.Memorabilia}/{EditModeType.Update.Name}");
    }

    protected void OnFilter(MemorabiliaSearchCriteria filter)
    {
        _filter = filter;
        ReloadGrid = true;
    }
}
