namespace Memorabilia.Blazor.Controls.Dialogs;

public partial class DeleteDialog : ComponentBase
{
    [CascadingParameter]
    public MudDialogInstance MudDialog { get; set; }

    [Parameter] 
    public string ContentText { get; set; } 
        = "Do you really want to delete this record? This process cannot be undone.";

    public void Cancel()
    {
        MudDialog.Cancel();
    }

    public void Submit()
    {
        MudDialog.Close(DialogResult.Ok(true));
    }
}
