namespace Memorabilia.Blazor.Pages.ThroughTheMail;

public partial class AddThroughTheMailMemorabiliaDialog
{
    [Inject]
    public IDialogService DialogService { get; set; }

    [Inject]
    public ImageService ImageService { get; set; }

    [CascadingParameter]
    public MudDialogInstance MudDialog { get; set; }

    [Parameter]
    public int PersonId { get; set; }

    [Parameter]
    public DateTime? ReceivedDate { get; set; }

    [Parameter]
    public int ThroughTheMailId { get; set; }

    protected ThroughTheMailMemorabiliaEditModel ThroughTheMailMemorabilia { get; set; }
        = new();

    protected override void OnParametersSet()
    {
        ThroughTheMailMemorabilia.ReceivedDate = ReceivedDate;
        ThroughTheMailMemorabilia.ThroughTheMailId = ThroughTheMailId;
    }

    private async Task AddMemorabiliaLink()
    {
        var options = new DialogOptions()
        {
            MaxWidth = MaxWidth.Large,
            FullWidth = true,
            DisableBackdropClick = true
        };

        var dialog = DialogService.Show<SelectThroughTheMailMemorabiliaDialog>("Select Memorabilia", 
                                                                               new DialogParameters(), 
                                                                               options);
        var result = await dialog.Result;

        if (result.Canceled)
            return;

        var results = (Dictionary<string, string>)result.Data;

        _ = results["MemorabiliaId"].TryParse(out int memorabiliaId);
        
        ThroughTheMailMemorabilia.ItemTypeName = results["ItemTypeName"];
        ThroughTheMailMemorabilia.MemorabiliaId = memorabiliaId;
        ThroughTheMailMemorabilia.MemorabiliaImageFileName = results["MemorabiliaImageFileName"];
        ThroughTheMailMemorabilia.PersonId = PersonId;
    }

    protected void Add()
    {
        if (ThroughTheMailMemorabilia.MemorabiliaId == 0)
            return;

        MudDialog.Close(DialogResult.Ok(ThroughTheMailMemorabilia));
    }

    public void Cancel()
    {
        MudDialog.Cancel();
    }
}
