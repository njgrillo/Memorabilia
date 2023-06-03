namespace Memorabilia.Blazor.Pages.Project;

public partial class ProjectEditor
{
    [Inject]
    public CommandRouter CommandRouter { get; set; }

    [Inject]
    public IJSRuntime JSRuntime { get; set; }

    [Inject]
    public QueryRouter QueryRouter { get; set; }

    [Inject]
    public ISnackbar Snackbar { get; set; }

    [Inject]
    public ProjectValidator Validator { get; set; }

    [Parameter]
    public int Id { get; set; }

    [Parameter]
    public int UserId { get; set; }

    protected Type ProjectTypeComponent;

    protected ValidationResult ValidationResult { get; set; }

    protected Alert[] ValidationResultAlerts => ValidationResult != null
        ? ValidationResult.Errors.Select(error => new Alert(error.ErrorMessage, Severity.Error)).ToArray()
        : Array.Empty<Alert>();

    private SaveProjectViewModel _viewModel = new();    

    protected Dictionary<string, object> ProjectTypeParameters { get; set; } 
        = new Dictionary<string, object>();

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (ValidationResult != null && !ValidationResult.IsValid)
        {
            await JSRuntime.ScrollToAlert();
        }
    }

    protected override async Task OnInitializedAsync()
    {
        ProjectTypeParameters.Add("ProjectDetailsSet",
            EventCallback.Factory.Create<Dictionary<string, object>>(this, OnProjectDetailsSet));

        if (Id == 0)
        {
            _viewModel = new SaveProjectViewModel
            {
                UserId = UserId
            };

            return;
        }

        _viewModel = new SaveProjectViewModel(await QueryRouter.Send(new GetProjectQuery(Id)));

        ProjectTypeComponent = Type.GetType($"Memorabilia.Blazor.Pages.Project.ProjectTypeComponents.{_viewModel.ProjectType}Selector");
        
        SetProjectDetailsParameters();
    }

    protected void OnProjectTypeSelected(ProjectType projectType)
    {
        _viewModel.ProjectType = projectType;

        ProjectTypeComponent = Type.GetType($"Memorabilia.Blazor.Pages.Project.ProjectTypeComponents.{_viewModel.ProjectType}Selector");
     }

    protected void OnProjectDetailsSet(Dictionary<string, object> parameters)
    {
        var projectTypeParameters = new Dictionary<string, object>();

        switch (_viewModel.ProjectType.ToString())
        {
            case "BaseballType":
                _viewModel.Baseball.BaseballTypeId = (int)parameters["BaseballTypeId"];

                if (parameters.ContainsKey("TeamId"))
                    _viewModel.Baseball.TeamId = (int?)parameters["TeamId"];

                if (parameters.ContainsKey("Year"))
                    _viewModel.Baseball.Year = (int?)parameters["Year"];

                break;
            case "Card":
                _viewModel.Card.BrandId = (int)parameters["BrandId"];

                if (parameters.ContainsKey("TeamId"))
                    _viewModel.Card.TeamId = (int?)parameters["TeamId"];

                if (parameters.ContainsKey("Year"))
                    _viewModel.Card.Year = (int?)parameters["Year"];

                break;
            case "HallofFame":
                _viewModel.HallOfFame.SportLeagueLevelId = (int)parameters["SportLeagueLevelId"];

                if (parameters.ContainsKey("Year"))
                    _viewModel.HallOfFame.Year = (int?)parameters["Year"];

                if (parameters.ContainsKey("ItemTypeId"))
                    _viewModel.HallOfFame.ItemTypeId = (int?)parameters["ItemTypeId"];

                break;
            case "HelmetType":
                _viewModel.Helmet.HelmetTypeId = (int)parameters["HelmetTypeId"];

                if (parameters.ContainsKey("HelmetFinishId"))
                    _viewModel.Helmet.HelmetFinishId = (int?)parameters["HelmetFinishId"];

                if (parameters.ContainsKey("SizeId"))
                    _viewModel.Helmet.SizeId = (int?)parameters["SizeId"];

                break;
            case "ItemType":
                _viewModel.Item.ItemTypeId = (int)parameters["ItemTypeId"];

                if (parameters.ContainsKey("MultiSignedItem"))
                    _viewModel.Item.MultiSignedItem = (bool)parameters["MultiSignedItem"];

                break;
            case "Team":
                _viewModel.Team.TeamId = (int)parameters["TeamId"];

                if (parameters.ContainsKey("Year"))
                    _viewModel.Team.Year = (int?)parameters["Year"];
                break;
            case "WorldSeries":
                _viewModel.WorldSeries.TeamId = (int)parameters["TeamId"];

                if (parameters.ContainsKey("Year"))
                    _viewModel.WorldSeries.Year = (int?)parameters["Year"];

                if (parameters.ContainsKey("ItemTypeId"))
                    _viewModel.WorldSeries.ItemTypeId = (int?)parameters["ItemTypeId"];

                break;
            default:
                break;
        }
    }

    protected async Task OnSave()
    {
        var command = new SaveProject.Command(_viewModel);

        _viewModel.ValidationResult = Validator.Validate(command);

        if (!_viewModel.ValidationResult.IsValid)
            return;

        await CommandRouter.Send(command);

        Snackbar.Add("Project was saved successfully!", Severity.Success);

        await GetProjectMemorabiliaTeamUpdatedIds();
        await GetProjectPersonUpdatedIds();
    }

    protected async Task GetProjectMemorabiliaTeamUpdatedIds()
    {
        if (!_viewModel.MemorabiliaTeams.Any())
            return;

        var viewModel = new SaveProjectViewModel(await QueryRouter.Send(new GetProjectQuery(Id)));

        _viewModel.MemorabiliaTeams = viewModel.MemorabiliaTeams;
    }

    protected async Task GetProjectPersonUpdatedIds()
    {
        if (!_viewModel.People.Any())
            return;

        var viewModel = new SaveProjectViewModel(await QueryRouter.Send(new GetProjectQuery(Id)));

        _viewModel.People = viewModel.People;
    }

    protected void SetProjectDetailsParameters()
    {
        ProjectTypeParameters.Add("Disabled", _viewModel.Id > 0);

        switch (_viewModel.ProjectType.ToString())
        {
            case "BaseballType":
                ProjectTypeParameters.Add("BaseballTypeId", _viewModel.Baseball.BaseballTypeId);

                if (_viewModel.Baseball.TeamId.HasValue)
                    ProjectTypeParameters.Add("TeamId", _viewModel.Baseball.TeamId);

                if (_viewModel.Baseball.Year.HasValue)
                    ProjectTypeParameters.Add("Year", _viewModel.Baseball.Year);

                break;
            case "Card":
                ProjectTypeParameters.Add("BrandId", _viewModel.Card.BrandId);

                if (_viewModel.Card.TeamId.HasValue)
                    ProjectTypeParameters.Add("TeamId", _viewModel.Card.TeamId);

                if (_viewModel.Card.Year.HasValue)
                    ProjectTypeParameters.Add("Year", _viewModel.Card.Year);

                break;
            case "HallofFame":
                ProjectTypeParameters.Add("SportLeagueLevelId", _viewModel.HallOfFame.SportLeagueLevelId);

                if (_viewModel.HallOfFame.ItemTypeId.HasValue)
                    ProjectTypeParameters.Add("ItemTypeId", _viewModel.HallOfFame.ItemTypeId);

                if (_viewModel.HallOfFame.Year.HasValue)
                    ProjectTypeParameters.Add("Year", _viewModel.HallOfFame.Year);

                break;
            case "HelmetType":
                ProjectTypeParameters.Add("HelmetTypeId", _viewModel.Helmet.HelmetTypeId);

                if (_viewModel.Helmet.HelmetFinishId.HasValue)
                    ProjectTypeParameters.Add("HelmetFinishId", _viewModel.Helmet.HelmetFinishId);

                if (_viewModel.Helmet.SizeId.HasValue)
                    ProjectTypeParameters.Add("SizeId", _viewModel.Helmet.SizeId);

                break;
            case "ItemType":
                ProjectTypeParameters.Add("ItemTypeId", _viewModel.Item.ItemTypeId);
                ProjectTypeParameters.Add("MultiSignedItem", _viewModel.Item.MultiSignedItem);

                break;
            case "Team":
                ProjectTypeParameters.Add("TeamId", _viewModel.Team.TeamId);

                if (_viewModel.Team.Year.HasValue)
                    ProjectTypeParameters.Add("Year", _viewModel.Team.Year);

                break;
            case "WorldSeries":
                ProjectTypeParameters.Add("TeamId", _viewModel.WorldSeries.TeamId);

                if (_viewModel.WorldSeries.ItemTypeId.HasValue)
                    ProjectTypeParameters.Add("ItemTypeId", _viewModel.WorldSeries.ItemTypeId);

                if (_viewModel.WorldSeries.Year.HasValue)
                    ProjectTypeParameters.Add("Year", _viewModel.WorldSeries.Year);

                break;
            default:
                break;
        }
    }    
}
