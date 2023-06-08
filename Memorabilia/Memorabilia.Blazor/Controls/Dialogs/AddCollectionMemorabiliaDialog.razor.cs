namespace Memorabilia.Blazor.Controls.Dialogs;

public partial class AddCollectionMemorabiliaDialog
{
    [Inject]
    public IDialogService DialogService { get; set; }

    [CascadingParameter]
    public MudDialogInstance MudDialog { get; set; }

    [Parameter]
    public int UserId { get; set; }

    protected List<MemorabiliaItemModel> SelectedMemorabilia = new();

    private MemorabiliaSearchCriteria _filter = new();

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
