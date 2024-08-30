namespace Memorabilia.Blazor.Controls.History;

public partial class HistoryDialog
{
    [CascadingParameter]
    public MudDialogInstance MudDialog { get; set; }

    [Parameter]
    public RenderFragment Content { get; set; }

    public void Close()
    {
        MudDialog.Cancel();
    }
}
