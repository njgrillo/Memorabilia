namespace Memorabilia.Blazor.Controls.Dialogs;

public partial class SelectAutographDialog : ImagePage
{
    [CascadingParameter] 
    public MudDialogInstance MudDialog { get; set; }

    [Parameter]
    public int MemorabiliaId { get; set; }

    private bool _loaded;
    private int _memorabiliaId;
    private SelectMemorabiliaItemModel _viewModel = new();

    public void Cancel()
    {
        MudDialog.Cancel();
    }

    protected override async Task OnInitializedAsync()
    {
        if (MemorabiliaId == 0 || (_loaded && MemorabiliaId == _memorabiliaId))
            return;

        _viewModel = new SelectMemorabiliaItemModel(await QueryRouter.Send(new GetSelectMemorabiliaItem(MemorabiliaId)));

        _loaded = true;
        _memorabiliaId = MemorabiliaId;
    }

    protected void Select(int autographId)
    {
        MudDialog.Close(DialogResult.Ok(autographId));
    }
}
