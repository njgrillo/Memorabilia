namespace Memorabilia.Blazor.Controls.Dialogs;

public partial class AddProjectMemorabiliaTeamDialog
{
    [Inject]
    public IDialogService DialogService { get; set; }

    [Inject]
    public ImageService ImageService { get; set; }

    [Inject]
    public QueryRouter QueryRouter { get; set; }

    [CascadingParameter]
    public MudDialogInstance MudDialog { get; set; }

    [Parameter]
    public int ItemTypeId { get; set; }

    [Parameter]
    public int MaxRank { get; set; }

    [Parameter]
    public int ProjectId { get; set; }

    [Parameter]
    public string Title { get; set; }

    [Parameter]
    public int UserId { get; set; }

    protected ProjectEditModel Project;

    protected ProjectMemorabiliaTeamEditModel ProjectMemorabiliaTeam = new();

    protected override async Task OnInitializedAsync()
    {
        if (ProjectId == 0)
            return;

        Project = new ProjectEditModel(new ProjectModel(await QueryRouter.Send(new GetProjectQuery(ProjectId))));
    }

    protected void Add()
    {
        if (ProjectMemorabiliaTeam.Team == null)
            return;

        ProjectMemorabiliaTeam.ItemTypeId = ItemTypeId;
        ProjectMemorabiliaTeam.Id = ProjectId;
        ProjectMemorabiliaTeam.UserId = UserId;

        MudDialog.Close(DialogResult.Ok(ProjectMemorabiliaTeam));
    }

    private async Task AddMemorabiliaLink(ProjectMemorabiliaTeamEditModel projectMemorabiliaTeam)
    {
        var parameters = new Dictionary<string, object>
        {
            ["UserId"] = UserId,
            ["ItemTypeId"] = ItemTypeId,
            ["TeamId"] = projectMemorabiliaTeam.Team.Id,
            ["DomainImageRootPath"] = ImagePath.DomainImageRootPath,
            ["ImageRootPath"] = Path.Combine(ImagePath.MemorabiliaImageRootPath, UserId.ToString())
        };

        SetProjectDetailsParameters(parameters);

        var dialogParameters = new DialogParameters
        {
            ["Parameters"] = parameters,
        };

        var options = new DialogOptions()
        {
            MaxWidth = MaxWidth.Large,
            FullWidth = true,
            DisableBackdropClick = true
        };

        var dialog = DialogService.Show<SelectProjectMemorabiliaDialog>("Select Memorabilia", dialogParameters, options);
        var result = await dialog.Result;

        if (result.Canceled)
            return;

        var results = (Dictionary<string, string>)result.Data;

        _ = int.TryParse(results["MemorabiliaId"], out int memorabiliaId);

        projectMemorabiliaTeam.MemorabiliaId = memorabiliaId;
        projectMemorabiliaTeam.MemorabiliaFileName = results["MemorabiliaFileName"];
    }

    public void Cancel()
    {
        MudDialog.Cancel();
    }

    protected void SetProjectDetailsParameters(Dictionary<string, object> parameters)
    {
        var projectType = ProjectType.Find(Project.ProjectType.Id);

        switch (projectType.ToString())
        {
            case "HelmetType":
                parameters.Add("HelmetTypeId", Project.Helmet.HelmetTypeId);

                if (Project.Helmet.HelmetFinishId.HasValue)
                    parameters.Add("HelmetFinishId", Project.Helmet.HelmetFinishId);

                if (Project.Helmet.SizeId.HasValue)
                    parameters.Add("HelmetSizeId", Project.Helmet.SizeId);

                break;
            case "Team":
                parameters.Add("TeamId", Project.Team.TeamId);

                if (Project.Team.Year.HasValue)
                    parameters.Add("TeamYear", Project.Team.Year);

                break;
            default:
                break;
        }
    }
}
