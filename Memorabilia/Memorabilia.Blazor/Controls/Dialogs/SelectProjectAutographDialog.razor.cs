namespace Memorabilia.Blazor.Controls.Dialogs;

public partial class SelectProjectAutographDialog
{
    [Inject]
    public ImageService ImageService { get; set; }

    [Inject]
    public QueryRouter QueryRouter { get; set; }

    [CascadingParameter]
    public MudDialogInstance MudDialog { get; set; }

    [Parameter]
    public Dictionary<string, object> Parameters { get; set; }

    protected int UserId
        => Parameters.ContainsKey("UserId")
        ? (int)Parameters["UserId"]
        : 0;

    protected AutographModel[] Model 
        = Array.Empty<AutographModel>();

    protected override async Task OnInitializedAsync()
    {
        if (!Parameters.Any())
            return;

        Entity.Autograph[] autographs = await QueryRouter.Send(new GetProjectPersonAutographLinks(Parameters));

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
            { "AutographFileName", autograph.PrimaryImageName }
        };

        MudDialog.Close(DialogResult.Ok(results));
    }
}
