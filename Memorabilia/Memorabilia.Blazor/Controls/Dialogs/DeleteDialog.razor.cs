#nullable disable

namespace Memorabilia.Blazor.Controls.Dialogs;

public partial class DeleteDialog : ComponentBase
{
    [CascadingParameter] MudDialogInstance MudDialog { get; set; }

    [Parameter] public string ButtonText { get; set; } = "Delete";

    [Parameter] public Color Color { get; set; } = Color.Error;

    [Parameter] public string ContentText { get; set; } = "Do you really want to delete this record? This process cannot be undone.";

    public void Cancel()
    {
        MudDialog.Cancel();
    }

    public void Submit()
    {
        MudDialog.Close(DialogResult.Ok(true));
    }
}
