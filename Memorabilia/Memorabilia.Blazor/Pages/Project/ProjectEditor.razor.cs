namespace Memorabilia.Blazor.Pages.Project;

public partial class ProjectEditor
{
    [Inject]
    public IApplicationStateService ApplicationStateService { get; set; }

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

    protected bool Loaded;

    protected ProjectEditModel EditModel 
        = new();

    protected Type ProjectTypeComponent;

    protected Alert[] ValidationResultAlerts 
        => EditModel.ValidationResult.Errors?.Any() ?? false
        ? EditModel.ValidationResult.Errors.Select(error => new Alert(error.ErrorMessage, Severity.Error)).ToArray()
        : Array.Empty<Alert>();    

    protected Dictionary<string, object> ProjectTypeParameters { get; set; } 
        = new Dictionary<string, object>();

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (EditModel.ValidationResult.IsValid)
            return;

        await JSRuntime.ScrollToAlert();
    }

    protected override async Task OnInitializedAsync()
    {
        ProjectTypeParameters.Add("ProjectDetailsSet",
            EventCallback.Factory.Create<Dictionary<string, object>>(this, OnProjectDetailsSet));

        if (Id == 0)
        {
            EditModel = new ProjectEditModel
            {
                UserId = ApplicationStateService.CurrentUser.Id
            };

            return;
        }

        EditModel = new ProjectEditModel(new ProjectModel(await QueryRouter.Send(new GetProjectQuery(Id))));

        ProjectTypeComponent = Type.GetType($"Memorabilia.Blazor.Pages.Project.ProjectTypeComponents.{EditModel.ProjectType}Selector");
        
        SetProjectDetailsParameters();

        Loaded = true;
    }

    protected void OnProjectTypeSelected(ProjectType projectType)
    {
        EditModel.ProjectType = projectType;

        ProjectTypeComponent = Type.GetType($"Memorabilia.Blazor.Pages.Project.ProjectTypeComponents.{EditModel.ProjectType}Selector");
     }

    protected void OnProjectDetailsSet(Dictionary<string, object> parameters)
    {
        var projectTypeParameters = new Dictionary<string, object>();

        switch (EditModel.ProjectType.ToString())
        {
            case "BaseballType":
                EditModel.Baseball.BaseballTypeId = (int)parameters["BaseballTypeId"];

                if (parameters.ContainsKey("TeamId"))
                    EditModel.Baseball.TeamId = (int?)parameters["TeamId"];

                if (parameters.ContainsKey("Year"))
                    EditModel.Baseball.Year = (int?)parameters["Year"];

                break;
            case "Card":
                EditModel.Card.BrandId = (int)parameters["BrandId"];

                if (parameters.ContainsKey("TeamId"))
                    EditModel.Card.TeamId = (int?)parameters["TeamId"];

                if (parameters.ContainsKey("Year"))
                    EditModel.Card.Year = (int?)parameters["Year"];

                break;
            case "HallofFame":
                EditModel.HallOfFame.SportLeagueLevelId = (int)parameters["SportLeagueLevelId"];

                if (parameters.ContainsKey("Year"))
                    EditModel.HallOfFame.Year = (int?)parameters["Year"];

                if (parameters.ContainsKey("ItemTypeId"))
                    EditModel.HallOfFame.ItemTypeId = (int?)parameters["ItemTypeId"];

                break;
            case "HelmetType":
                EditModel.Helmet.HelmetTypeId = (int)parameters["HelmetTypeId"];

                if (parameters.ContainsKey("HelmetFinishId"))
                    EditModel.Helmet.HelmetFinishId = (int?)parameters["HelmetFinishId"];

                if (parameters.ContainsKey("SizeId"))
                    EditModel.Helmet.SizeId = (int?)parameters["SizeId"];

                break;
            case "ItemType":
                EditModel.Item.ItemTypeId = (int)parameters["ItemTypeId"];

                if (parameters.ContainsKey("MultiSignedItem"))
                    EditModel.Item.MultiSignedItem = (bool)parameters["MultiSignedItem"];

                break;
            case "Team":
                EditModel.Team.TeamId = (int)parameters["TeamId"];

                if (parameters.ContainsKey("Year"))
                    EditModel.Team.Year = (int?)parameters["Year"];
                break;
            case "WorldSeries":
                EditModel.WorldSeries.TeamId = (int)parameters["TeamId"];

                if (parameters.ContainsKey("Year"))
                    EditModel.WorldSeries.Year = (int?)parameters["Year"];

                if (parameters.ContainsKey("ItemTypeId"))
                    EditModel.WorldSeries.ItemTypeId = (int?)parameters["ItemTypeId"];

                break;
            default:
                break;
        }
    }

    protected async Task OnSave()
    {
        var command = new SaveProject.Command(EditModel);

        EditModel.ValidationResult = Validator.Validate(command);

        if (!EditModel.ValidationResult.IsValid)
            return;

        await CommandRouter.Send(command);

        Snackbar.Add("Project was saved successfully!", Severity.Success);

        await GetProjectMemorabiliaTeamUpdatedIds();
        await GetProjectPersonUpdatedIds();
    }

    protected async Task GetProjectMemorabiliaTeamUpdatedIds()
    {
        if (!EditModel.MemorabiliaTeams.Any())
            return;

        ProjectEditModel editModel = (await QueryRouter.Send(new GetProjectQuery(Id))).ToEditModel();

        EditModel.MemorabiliaTeams = editModel.MemorabiliaTeams;
    }

    protected async Task GetProjectPersonUpdatedIds()
    {
        if (!EditModel.People.Any())
            return;

        ProjectEditModel editModel = (await QueryRouter.Send(new GetProjectQuery(Id))).ToEditModel();

        EditModel.People = editModel.People;
    }

    protected void SetProjectDetailsParameters()
    {
        ProjectTypeParameters.Add("Disabled", EditModel.Id > 0);

        switch (EditModel.ProjectType.ToString())
        {
            case "BaseballType":
                ProjectTypeParameters.Add("BaseballTypeId", EditModel.Baseball.BaseballTypeId);

                if (EditModel.Baseball.TeamId.HasValue)
                    ProjectTypeParameters.Add("TeamId", EditModel.Baseball.TeamId);

                if (EditModel.Baseball.Year.HasValue)
                    ProjectTypeParameters.Add("Year", EditModel.Baseball.Year);

                break;
            case "Card":
                ProjectTypeParameters.Add("BrandId", EditModel.Card.BrandId);

                if (EditModel.Card.TeamId.HasValue)
                    ProjectTypeParameters.Add("TeamId", EditModel.Card.TeamId);

                if (EditModel.Card.Year.HasValue)
                    ProjectTypeParameters.Add("Year", EditModel.Card.Year);

                break;
            case "HallofFame":
                ProjectTypeParameters.Add("SportLeagueLevelId", EditModel.HallOfFame.SportLeagueLevelId);

                if (EditModel.HallOfFame.ItemTypeId.HasValue)
                    ProjectTypeParameters.Add("ItemTypeId", EditModel.HallOfFame.ItemTypeId);

                if (EditModel.HallOfFame.Year.HasValue)
                    ProjectTypeParameters.Add("Year", EditModel.HallOfFame.Year);

                break;
            case "HelmetType":
                ProjectTypeParameters.Add("HelmetTypeId", EditModel.Helmet.HelmetTypeId);

                if (EditModel.Helmet.HelmetFinishId.HasValue)
                    ProjectTypeParameters.Add("HelmetFinishId", EditModel.Helmet.HelmetFinishId);

                if (EditModel.Helmet.SizeId.HasValue)
                    ProjectTypeParameters.Add("SizeId", EditModel.Helmet.SizeId);

                break;
            case "ItemType":
                ProjectTypeParameters.Add("ItemTypeId", EditModel.Item.ItemTypeId);
                ProjectTypeParameters.Add("MultiSignedItem", EditModel.Item.MultiSignedItem);

                break;
            case "Team":
                ProjectTypeParameters.Add("TeamId", EditModel.Team.TeamId);

                if (EditModel.Team.Year.HasValue)
                    ProjectTypeParameters.Add("Year", EditModel.Team.Year);

                break;
            case "WorldSeries":
                ProjectTypeParameters.Add("TeamId", EditModel.WorldSeries.TeamId);

                if (EditModel.WorldSeries.ItemTypeId.HasValue)
                    ProjectTypeParameters.Add("ItemTypeId", EditModel.WorldSeries.ItemTypeId);

                if (EditModel.WorldSeries.Year.HasValue)
                    ProjectTypeParameters.Add("Year", EditModel.WorldSeries.Year);

                break;
            default:
                break;
        }
    }    
}
