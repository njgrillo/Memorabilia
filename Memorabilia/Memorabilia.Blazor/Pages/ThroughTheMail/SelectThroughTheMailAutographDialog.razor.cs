namespace Memorabilia.Blazor.Pages.ThroughTheMail;

public partial class SelectThroughTheMailAutographDialog
{
    [Inject]
    public ImageService ImageService { get; set; }    

    [Inject]
    public QueryRouter QueryRouter { get; set; }

    [CascadingParameter]
    public MudDialogInstance MudDialog { get; set; }

    [Parameter]
    public int PersonId { get; set; }

    protected AutographModel[] Model
        = Array.Empty<AutographModel>();

    protected override async Task OnInitializedAsync()
    {
        if (PersonId == 0)
            return;

        Entity.Autograph[] autographs
            = await QueryRouter.Send(new GetAutographsByPerson(PersonId));

        Model = autographs.Any()
                ? autographs.Select(autograph => new AutographModel(autograph))
                            .ToArray()
                : Array.Empty<AutographModel>();
    }

    public void Cancel()
    {
        MudDialog.Cancel();
    }

    protected void Select(AutographModel autograph)
    {
        var results = new Dictionary<string, string>()
        {
            { "AutographId", autograph.Id.ToString() },
            { "AutographImageFileName", autograph.PrimaryImageName },
            { "ItemTypeName", autograph.ItemType.Name},
            { "MemorabiliaId", autograph.MemorabiliaId.ToString() }
        };

        MudDialog.Close(DialogResult.Ok(results));
    }
}
