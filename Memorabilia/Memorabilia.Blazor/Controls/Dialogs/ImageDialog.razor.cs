namespace Memorabilia.Blazor.Controls.Dialogs;

public partial class ImageDialog
{
    [Inject]
    public ImageService ImageService { get; set; }

    [CascadingParameter]
    public MudDialogInstance MudDialog { get; set; }

    [Parameter]
    public string ImageFileName { get; set; }

    [Parameter]
    public int UserId { get; set; }

    public void Close()
    {
        MudDialog.Cancel();
    }
}
