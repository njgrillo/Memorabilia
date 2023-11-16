namespace Memorabilia.Blazor.Pages.Transaction;

public partial class AddPartialTradeMemorabiliaDialog
{
    [Inject]
    public IDialogService DialogService { get; set; }

    [CascadingParameter]
    public MudDialogInstance MudDialog { get; set; }

    protected static int[] AcquisitionTypeIds
        => new int[] { AcquisitionType.PartialTrade.Id };

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
