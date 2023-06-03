namespace Memorabilia.Blazor.Controls.Dialogs;

public partial class AddProjectPersonDialog
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
    private SaveProjectPersonViewModel _viewModel = new();

    protected override async Task OnInitializedAsync()
    {
        if (ProjectId == 0)
            return;

        _project = new SaveProjectViewModel(await QueryRouter.Send(new GetProjectQuery(ProjectId)));
    }

    protected void Add()
    {
        if (_viewModel.Person == null)
            return;

        _viewModel.ItemTypeId = ItemTypeId;
        _viewModel.Id = ProjectId;
        _viewModel.UserId = UserId;

        MudDialog.Close(DialogResult.Ok(_viewModel));
    }

    private async Task AddAutographLink(SaveProjectPersonViewModel projectPerson)
    {
        var parameters = new Dictionary<string, object>
        {
            ["UserId"] = UserId,
            ["ItemTypeId"] = ItemTypeId,
            ["PersonId"] = projectPerson.Person.Id,
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

        var dialog = DialogService.Show<SelectProjectAutographDialog>("Select Autograph", dialogParameters, options);
        var result = await dialog.Result;

        if (result.Canceled)
            return;

        var results = (Dictionary<string, string>)result.Data;

        _ = int.TryParse(results["AutographId"], out int autographId);

        projectPerson.AutographId = autographId;
        projectPerson.AutographFileName = results["AutographFileName"];
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
            case "BaseballType":
                parameters.Add("BaseballTypeId", _project.Baseball.BaseballTypeId);

                if (_project.Baseball.TeamId.HasValue)
                    parameters.Add("BaseballTypeTeamId", _project.Baseball.TeamId);

                if (_project.Baseball.Year.HasValue)
                    parameters.Add("BaseballTypeYear", _project.Baseball.Year);

                break;
            case "Card":
                parameters.Add("CardBrandId", _project.Card.BrandId);

                if (_project.Card.TeamId.HasValue)
                    parameters.Add("CardTeamId", _project.Card.TeamId);

                if (_project.Card.Year.HasValue)
                    parameters.Add("CardYear", _project.Card.Year);

                break;
            case "HallofFame":
                parameters.Add("HallOfFameSportLeagueLevelId", _project.HallOfFame.SportLeagueLevelId);

                if (_project.HallOfFame.ItemTypeId.HasValue)
                    parameters.Add("HallOfFameItemTypeId", _project.HallOfFame.ItemTypeId);

                if (_project.HallOfFame.Year.HasValue)
                    parameters.Add("HallOfFameYear", _project.HallOfFame.Year);

                break;
            case "ItemType":
                if (!parameters.ContainsKey("ItemTypeId"))
                    parameters.Add("ItemTypeId", _project.Item.ItemTypeId);

                parameters.Add("MultiSignedItem", _project.Item.MultiSignedItem);

                break;
            case "Team":
                parameters.Add("TeamId", _project.Team.TeamId);

                if (_project.Team.Year.HasValue)
                    parameters.Add("TeamYear", _project.Team.Year);

                break;
            case "WorldSeries":
                parameters.Add("WorldSeriesTeamId", _project.WorldSeries.TeamId);

                if (_project.WorldSeries.ItemTypeId.HasValue)
                    parameters.Add("WorldSeriesItemTypeId", _project.WorldSeries.ItemTypeId);

                if (_project.WorldSeries.Year.HasValue)
                    parameters.Add("WorldSeriesYear", _project.WorldSeries.Year);

                break;
            default:
                break;
        }
    }
}
