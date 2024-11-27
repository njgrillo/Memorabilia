namespace Memorabilia.Blazor.Controls.Dialogs;

public partial class OkDialog
{
    [CascadingParameter]
    public MudDialogInstance MudDialog { get; set; }

    [Parameter]
    public string ContentText { get; set; }

    public void Confirm()
    {
        MudDialog.Close(DialogResult.Ok(true));
    }
}
