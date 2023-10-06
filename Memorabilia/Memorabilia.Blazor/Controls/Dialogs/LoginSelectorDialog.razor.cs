namespace Memorabilia.Blazor.Controls.Dialogs;

public partial class LoginSelectorDialog
{
    [Inject]
    public ImageService ImageService { get; set; }

    [CascadingParameter]
    public MudDialogInstance MudDialog { get; set; }

    public void Cancel()
    {
        MudDialog.Cancel();
    }

    protected void Select(LoginProvider provider)
    {
        MudDialog.Close(DialogResult.Ok(provider));
    }
}
