namespace Memorabilia.Blazor.Pages.Tools.Profile;

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
