namespace Memorabilia.Blazor.Pages.Project;

public partial class SelectProjectAutographDialog
{
    [Inject]
    public ImageService ImageService { get; set; }

    [Inject]
    public ProjectAutographPersonLinkService ProjectAutographPersonLinkService { get; set; }

    [CascadingParameter]
    public MudDialogInstance MudDialog { get; set; }

    [Parameter]
    public Dictionary<string, object> Parameters { get; set; }    

    protected AutographModel[] Model 
        = Array.Empty<AutographModel>();

    protected override async Task OnInitializedAsync()
    {
        if (!Parameters.Any())
            return;

        bool hasProjectType = Parameters["ProjectTypeId"].ToString().TryParse(out int projectTypeId);

        if (!hasProjectType)
            throw new NotImplementedException();

        Entity.Autograph[] autographs 
            = await ProjectAutographPersonLinkService.GetAutographs(ProjectType.Find(projectTypeId), Parameters);

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
