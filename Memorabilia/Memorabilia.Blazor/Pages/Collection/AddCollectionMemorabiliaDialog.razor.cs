namespace Memorabilia.Blazor.Pages.Collection;

public partial class AddCollectionMemorabiliaDialog
{
    [CascadingParameter]
    public MudDialogInstance MudDialog { get; set; }

    protected List<MemorabiliaModel> SelectedMemorabilia 
        = [];

    private MemorabiliaSearchCriteria _filter 
        = new();

    protected void Add()
    {
        MudDialog.Close(DialogResult.Ok(SelectedMemorabilia));
    }

    public void Cancel()
    {
        MudDialog.Cancel();
    }

    protected void OnFilter(MemorabiliaSearchCriteria filter)
    {
        _filter = filter;
    }
}
