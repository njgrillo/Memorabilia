namespace Memorabilia.Blazor.Controls.Dialogs;

public partial class AddProjectPersonDialog
{
    [CascadingParameter]
    public MudDialogInstance MudDialog { get; set; }

    [Parameter]
    public int ItemTypeId { get; set; }

    [Parameter]
    public string Title { get; set; }

    private SaveProjectPersonViewModel _viewModel = new();

    protected void Add()
    {
        _viewModel.ItemTypeId = ItemTypeId;

        MudDialog.Close(DialogResult.Ok(_viewModel));
    }

    public void Cancel()
    {
        MudDialog.Cancel();
    }    
}
