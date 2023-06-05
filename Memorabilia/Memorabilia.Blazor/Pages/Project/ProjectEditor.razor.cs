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

    protected ProjectEditModel Model = new();

    protected Type ProjectTypeComponent;

    protected ValidationResult ValidationResult { get; set; }

    protected Alert[] ValidationResultAlerts => ValidationResult != null
        ? ValidationResult.Errors.Select(error => new Alert(error.ErrorMessage, Severity.Error)).ToArray()
        : Array.Empty<Alert>();    

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
            Model = new ProjectEditModel
            {
                UserId = UserId
            };

            return;
        }

        Model = new ProjectEditModel(new ProjectModel(await QueryRouter.Send(new GetProjectQuery(Id))));

        ProjectTypeComponent = Type.GetType($"Memorabilia.Blazor.Pages.Project.ProjectTypeComponents.{Model.ProjectType}Selector");
        
        SetProjectDetailsParameters();
    }

    protected void OnProjectTypeSelected(ProjectType projectType)
    {
        Model.ProjectType = projectType;

        ProjectTypeComponent = Type.GetType($"Memorabilia.Blazor.Pages.Project.ProjectTypeComponents.{Model.ProjectType}Selector");
     }

    protected void OnProjectDetailsSet(Dictionary<string, object> parameters)
    {
        var projectTypeParameters = new Dictionary<string, object>();

        switch (Model.ProjectType.ToString())
        {
            case "BaseballType":
                Model.Baseball.BaseballTypeId = (int)parameters["BaseballTypeId"];

                if (parameters.ContainsKey("TeamId"))
                    Model.Baseball.TeamId = (int?)parameters["TeamId"];

                if (parameters.ContainsKey("Year"))
                    Model.Baseball.Year = (int?)parameters["Year"];

                break;
            case "Card":
                Model.Card.BrandId = (int)parameters["BrandId"];

                if (parameters.ContainsKey("TeamId"))
                    Model.Card.TeamId = (int?)parameters["TeamId"];

                if (parameters.ContainsKey("Year"))
                    Model.Card.Year = (int?)parameters["Year"];

                break;
            case "HallofFame":
                Model.HallOfFame.SportLeagueLevelId = (int)parameters["SportLeagueLevelId"];

                if (parameters.ContainsKey("Year"))
                    Model.HallOfFame.Year = (int?)parameters["Year"];

                if (parameters.ContainsKey("ItemTypeId"))
                    Model.HallOfFame.ItemTypeId = (int?)parameters["ItemTypeId"];

                break;
            case "HelmetType":
                Model.Helmet.HelmetTypeId = (int)parameters["HelmetTypeId"];

                if (parameters.ContainsKey("HelmetFinishId"))
                    Model.Helmet.HelmetFinishId = (int?)parameters["HelmetFinishId"];

                if (parameters.ContainsKey("SizeId"))
                    Model.Helmet.SizeId = (int?)parameters["SizeId"];

                break;
            case "ItemType":
                Model.Item.ItemTypeId = (int)parameters["ItemTypeId"];

                if (parameters.ContainsKey("MultiSignedItem"))
                    Model.Item.MultiSignedItem = (bool)parameters["MultiSignedItem"];

                break;
            case "Team":
                Model.Team.TeamId = (int)parameters["TeamId"];

                if (parameters.ContainsKey("Year"))
                    Model.Team.Year = (int?)parameters["Year"];
                break;
            case "WorldSeries":
                Model.WorldSeries.TeamId = (int)parameters["TeamId"];

                if (parameters.ContainsKey("Year"))
                    Model.WorldSeries.Year = (int?)parameters["Year"];

                if (parameters.ContainsKey("ItemTypeId"))
                    Model.WorldSeries.ItemTypeId = (int?)parameters["ItemTypeId"];

                break;
            default:
                break;
        }
    }

    protected async Task OnSave()
    {
        var command = new SaveProject.Command(Model);

        Model.ValidationResult = Validator.Validate(command);

        if (!Model.ValidationResult.IsValid)
            return;

        await CommandRouter.Send(command);

        Snackbar.Add("Project was saved successfully!", Severity.Success);

        await GetProjectMemorabiliaTeamUpdatedIds();
        await GetProjectPersonUpdatedIds();
    }

    protected async Task GetProjectMemorabiliaTeamUpdatedIds()
    {
        if (!Model.MemorabiliaTeams.Any())
            return;

        var viewModel = new ProjectEditModel(new ProjectModel(await QueryRouter.Send(new GetProjectQuery(Id))));

        Model.MemorabiliaTeams = viewModel.MemorabiliaTeams;
    }

    protected async Task GetProjectPersonUpdatedIds()
    {
        if (!Model.People.Any())
            return;

        var viewModel = new ProjectEditModel(new ProjectModel(await QueryRouter.Send(new GetProjectQuery(Id))));

        Model.People = viewModel.People;
    }

    protected void SetProjectDetailsParameters()
    {
        ProjectTypeParameters.Add("Disabled", Model.Id > 0);

        switch (Model.ProjectType.ToString())
        {
            case "BaseballType":
                ProjectTypeParameters.Add("BaseballTypeId", Model.Baseball.BaseballTypeId);

                if (Model.Baseball.TeamId.HasValue)
                    ProjectTypeParameters.Add("TeamId", Model.Baseball.TeamId);

                if (Model.Baseball.Year.HasValue)
                    ProjectTypeParameters.Add("Year", Model.Baseball.Year);

                break;
            case "Card":
                ProjectTypeParameters.Add("BrandId", Model.Card.BrandId);

                if (Model.Card.TeamId.HasValue)
                    ProjectTypeParameters.Add("TeamId", Model.Card.TeamId);

                if (Model.Card.Year.HasValue)
                    ProjectTypeParameters.Add("Year", Model.Card.Year);

                break;
            case "HallofFame":
                ProjectTypeParameters.Add("SportLeagueLevelId", Model.HallOfFame.SportLeagueLevelId);

                if (Model.HallOfFame.ItemTypeId.HasValue)
                    ProjectTypeParameters.Add("ItemTypeId", Model.HallOfFame.ItemTypeId);

                if (Model.HallOfFame.Year.HasValue)
                    ProjectTypeParameters.Add("Year", Model.HallOfFame.Year);

                break;
            case "HelmetType":
                ProjectTypeParameters.Add("HelmetTypeId", Model.Helmet.HelmetTypeId);

                if (Model.Helmet.HelmetFinishId.HasValue)
                    ProjectTypeParameters.Add("HelmetFinishId", Model.Helmet.HelmetFinishId);

                if (Model.Helmet.SizeId.HasValue)
                    ProjectTypeParameters.Add("SizeId", Model.Helmet.SizeId);

                break;
            case "ItemType":
                ProjectTypeParameters.Add("ItemTypeId", Model.Item.ItemTypeId);
                ProjectTypeParameters.Add("MultiSignedItem", Model.Item.MultiSignedItem);

                break;
            case "Team":
                ProjectTypeParameters.Add("TeamId", Model.Team.TeamId);

                if (Model.Team.Year.HasValue)
                    ProjectTypeParameters.Add("Year", Model.Team.Year);

                break;
            case "WorldSeries":
                ProjectTypeParameters.Add("TeamId", Model.WorldSeries.TeamId);

                if (Model.WorldSeries.ItemTypeId.HasValue)
                    ProjectTypeParameters.Add("ItemTypeId", Model.WorldSeries.ItemTypeId);

                if (Model.WorldSeries.Year.HasValue)
                    ProjectTypeParameters.Add("Year", Model.WorldSeries.Year);

                break;
            default:
                break;
        }
    }    
}
