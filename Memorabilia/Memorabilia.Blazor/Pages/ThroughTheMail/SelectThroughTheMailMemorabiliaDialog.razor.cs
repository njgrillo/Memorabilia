namespace Memorabilia.Blazor.Pages.ThroughTheMail;

public partial class SelectThroughTheMailMemorabiliaDialog
{
    [Inject]
    public ImageService ImageService { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Inject]
    public QueryRouter QueryRouter { get; set; }

    [CascadingParameter]
    public MudDialogInstance MudDialog { get; set; }

    protected MemorabiliaModel[] Items
        = Array.Empty<MemorabiliaModel>();

    protected override async Task OnInitializedAsync()
    {
        Entity.Memorabilia[] memorabilia
            = await QueryRouter.Send(new GetUnsignedMemorabiliaItems());

        Items = memorabilia.Any()
            ? memorabilia.Select(item => new MemorabiliaModel(item))
                         .ToArray()
            : Array.Empty<MemorabiliaModel>();
    }

    public void Cancel()
    {
        MudDialog.Cancel();
    }

    protected void Select(MemorabiliaModel memorabilia)
    {
        var results = new Dictionary<string, string>()
        {
            { "ItemTypeName", memorabilia.ItemTypeName },
            { "MemorabiliaId", memorabilia.Id.ToString() },
            { "MemorabiliaImageFileName", memorabilia.ImageFileName }
        };

        MudDialog.Close(DialogResult.Ok(results));
    }
}
