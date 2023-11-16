namespace Memorabilia.Blazor.Pages.ThroughTheMail;

public partial class SelectThroughTheMailMemorabiliaDialog
{
    [Inject]
    public IDataProtectorService DataProtectorService { get; set; }

    [Inject]
    public ImageService ImageService { get; set; }

    [Inject]
    public IMediator Mediator { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [CascadingParameter]
    public MudDialogInstance MudDialog { get; set; }

    protected MemorabiliaModel[] Items
        = [];

    protected override async Task OnInitializedAsync()
    {
        Entity.Memorabilia[] memorabilia
            = await Mediator.Send(new GetUnsignedMemorabiliaItems());

        Items = memorabilia.Length != 0
            ? memorabilia.Select(item => new MemorabiliaModel(item))
                         .ToArray()
            : [];
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
