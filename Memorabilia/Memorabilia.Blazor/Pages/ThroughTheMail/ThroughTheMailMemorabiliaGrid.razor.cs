namespace Memorabilia.Blazor.Pages.ThroughTheMail;

public partial class ThroughTheMailMemorabiliaGrid
{
    [Inject]
    public IDataProtectorService DataProtectorService { get; set; }

    [Inject]
    public IDialogService DialogService { get; set; }

    [Inject]
    public ImageService ImageService { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Parameter]
    public List<ThroughTheMailMemorabiliaEditModel> Items { get; set; }
        = [];

    private ThroughTheMailMemorabiliaEditModel _elementBeforeEdit;

    protected async Task AddAutographLink(ThroughTheMailMemorabiliaEditModel editModel)
    {
        var dialogParameters = new DialogParameters
        {
            ["PersonId"] = editModel.PersonId
        };

        var options = new DialogOptions()
        {
            MaxWidth = MaxWidth.Large,
            FullWidth = true,
            DisableBackdropClick = true
        };

        var dialog = DialogService.Show<SelectThroughTheMailAutographDialog>("Select Autograph", dialogParameters, options);
        var result = await dialog.Result;

        if (result.Canceled)
            return;

        var results = (Dictionary<string, string>)result.Data;

        _ = results["AutographId"].TryParse(out int autographId);
        _ = results["MemorabiliaId"].TryParse(out int memorabiliaId);

        editModel.AutographId = autographId;
        editModel.AutographImageFileName = results["AutographImageFileName"];
        editModel.ItemTypeName = results["ItemTypeName"];
        editModel.MemorabiliaId = memorabiliaId;
    }

    protected void Navigate(string path)
    {
        NavigationManager.NavigateTo(path);
    }

    private void BackupItem(object element)
    {
        _elementBeforeEdit = new()
        {
            Cost = ((ThroughTheMailMemorabiliaEditModel)element).Cost,
        };
    }

    private void ResetItemToOriginalValues(object element)
    {
        ((ThroughTheMailMemorabiliaEditModel)element).Cost = _elementBeforeEdit.Cost;
    }

    private void UpdateCost(object element)
    {
        StateHasChanged();
    }
}
