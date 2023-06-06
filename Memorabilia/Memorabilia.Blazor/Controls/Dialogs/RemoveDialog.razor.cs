namespace Memorabilia.Blazor.Controls.Dialogs;

public partial class RemoveDialog
{
    [CascadingParameter]
    public MudDialogInstance MudDialog { get; set; }

    [Parameter]
    public string ContentText { get; set; }
        = "Do you really want to remove this record? This process cannot be undone.";

    public void Cancel()
    {
        MudDialog.Cancel();
    }

    public void Submit()
    {
        MudDialog.Close(DialogResult.Ok(true));
    }
}
