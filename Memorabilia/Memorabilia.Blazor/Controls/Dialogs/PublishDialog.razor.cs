namespace Memorabilia.Blazor.Controls.Dialogs;

public partial class PublishDialog
{
    [CascadingParameter]
    public MudDialogInstance MudDialog { get; set; }

    [Parameter]
    public string ContentText { get; set; }
        = "Are you sure you want to publish this signing?  This process cannot be undone.";

    public void Cancel()
    {
        MudDialog.Cancel();
    }

    public void Submit()
    {
        MudDialog.Close(DialogResult.Ok(true));
    }
}
