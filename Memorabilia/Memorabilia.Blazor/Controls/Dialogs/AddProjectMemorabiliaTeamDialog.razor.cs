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

    private SaveProjectViewModel _project;
    private SaveProjectMemorabiliaTeamViewModel _viewModel = new();

    protected override async Task OnInitializedAsync()
    {
        if (ProjectId == 0)
            return;

        _project = new SaveProjectViewModel(await QueryRouter.Send(new GetProjectQuery(ProjectId)));
    }

    protected void Add()
    {
        if (_viewModel.Team == null)
            return;

        _viewModel.ItemTypeId = ItemTypeId;
        _viewModel.Id = ProjectId;
        _viewModel.UserId = UserId;

        MudDialog.Close(DialogResult.Ok(_viewModel));
    }

    private async Task AddMemorabiliaLink(SaveProjectMemorabiliaTeamViewModel projectMemorabiliaTeam)
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
        var projectType = ProjectType.Find(_project.ProjectType.Id);

        switch (projectType.ToString())
        {
            case "HelmetType":
                parameters.Add("HelmetTypeId", _project.Helmet.HelmetTypeId);

                if (_project.Helmet.HelmetFinishId.HasValue)
                    parameters.Add("HelmetFinishId", _project.Helmet.HelmetFinishId);

                if (_project.Helmet.SizeId.HasValue)
                    parameters.Add("HelmetSizeId", _project.Helmet.SizeId);

                break;
            case "Team":
                parameters.Add("TeamId", _project.Team.TeamId);

                if (_project.Team.Year.HasValue)
                    parameters.Add("TeamYear", _project.Team.Year);

                break;
            default:
                break;
        }
    }
}
