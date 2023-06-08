namespace Memorabilia.Blazor.Controls.Dialogs;

public partial class PersonProfileDialog
{
    [CascadingParameter]
    public MudDialogInstance MudDialog { get; set; }

    [Parameter]
    public int PersonId { get; set; }

    public void Close()
    {
        MudDialog.Cancel();
    }
}
