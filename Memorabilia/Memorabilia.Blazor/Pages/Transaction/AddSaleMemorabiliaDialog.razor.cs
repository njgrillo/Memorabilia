namespace Memorabilia.Blazor.Pages.Transaction;

public partial class AddSaleMemorabiliaDialog
{
    [Inject]
    public IDialogService DialogService { get; set; }

    [CascadingParameter]
    public MudDialogInstance MudDialog { get; set; }

    protected List<MemorabiliaModel> SelectedMemorabilia
        = [];

    private MemorabiliaSearchCriteria _filter
        = new();

    private bool _reloadGrid;

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
        _reloadGrid = true;
        _filter = filter;
    }
}
