namespace Memorabilia.Blazor.Controls.Dialogs;

public partial class DomainItemBrowseDialog
{
    [CascadingParameter]
    public MudDialogInstance MudDialog { get; set; }

    [Parameter]
    public DomainItemConstant[] DomainItems { get; set; }

    [Parameter]
    public string Title { get; set; }

    public void Cancel()
    {
        MudDialog.Cancel();
    }

    protected void Select(int id)
    {
        MudDialog.Close(DialogResult.Ok(id));
    }
}
