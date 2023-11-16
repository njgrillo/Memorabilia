namespace Memorabilia.Blazor.Pages.Project;

public partial class EditProject
{
    [Inject]
    public IApplicationStateService ApplicationStateService { get; set; }

    [Inject]
    public IDataProtectorService DataProtectorService { get; set; }

    [Inject]
    public IJSRuntime JSRuntime { get; set; }

    [Inject]
    public IMediator Mediator { get; set; }

    [Inject]
    public ISnackbar Snackbar { get; set; }

    [Inject]
    public ProjectValidator Validator { get; set; }

    [Parameter]
    public string EncryptId { get; set; }

    protected bool Loaded;

    protected ProjectEditModel EditModel 
        = new();

    protected int Id;

    protected Type ProjectTypeComponent;

    protected Alert[] ValidationResultAlerts 
        => EditModel.ValidationResult.HasErrors()
            ? EditModel.ValidationResult.Errors.Select(error => new Alert(error.ErrorMessage, Severity.Error)).ToArray()
            : [];    

    protected Dictionary<string, object> ProjectTypeParameters { get; set; } 
        = [];

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

        Id = DataProtectorService.DecryptId(EncryptId);

        if (Id == 0)
        {
            EditModel = new ProjectEditModel
            {
                UserId = ApplicationStateService.CurrentUser.Id
            };

            return;
        }

        EditModel = new ProjectEditModel(new ProjectModel(await Mediator.Send(new GetProjectQuery(Id))));

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
        switch (EditModel.ProjectType.ToString())
        {
            case "BaseballType":
                EditModel.Baseball.BaseballTypeId = (int)parameters["BaseballTypeId"];

                if (parameters.TryGetValue("TeamId", out object baseballTypeTeamId))
                    EditModel.Baseball.TeamId = (int?)baseballTypeTeamId;

                if (parameters.TryGetValue("Year", out object baseballTypeYear))
                    EditModel.Baseball.Year = (int?)baseballTypeYear;

                break;
            case "Card":
                EditModel.Card.BrandId = (int)parameters["BrandId"];

                if (parameters.TryGetValue("TeamId", out object cardTeamId))
                    EditModel.Card.TeamId = (int?)cardTeamId;

                if (parameters.TryGetValue("Year", out object cardYear))
                    EditModel.Card.Year = (int?)cardYear;

                break;
            case "HallofFame":
                EditModel.HallOfFame.SportLeagueLevelId = (int)parameters["SportLeagueLevelId"];

                if (parameters.TryGetValue("Year", out object hallOfFameYear))
                    EditModel.HallOfFame.Year = (int?)hallOfFameYear;

                if (parameters.TryGetValue("ItemTypeId", out object hallOfFameItemTypeId))
                    EditModel.HallOfFame.ItemTypeId = (int?)hallOfFameItemTypeId;

                break;
            case "HelmetType":
                EditModel.Helmet.HelmetTypeId = (int)parameters["HelmetTypeId"];

                if (parameters.TryGetValue("HelmetFinishId", out object helmetTypeHelmetFinishId))
                    EditModel.Helmet.HelmetFinishId = (int?)helmetTypeHelmetFinishId;

                if (parameters.TryGetValue("SizeId", out object helmetTypeSizeId))
                    EditModel.Helmet.SizeId = (int?)helmetTypeSizeId;

                break;
            case "ItemType":
                EditModel.Item.ItemTypeId = (int)parameters["ItemTypeId"];

                if (parameters.TryGetValue("MultiSignedItem", out object multiSignedItem))
                    EditModel.Item.MultiSignedItem = (bool)multiSignedItem;

                break;
            case "Team":
                EditModel.Team.TeamId = (int)parameters["TeamId"];

                if (parameters.TryGetValue("Year", out object teamYear))
                    EditModel.Team.Year = (int?)teamYear;
                break;
            case "WorldSeries":
                EditModel.WorldSeries.TeamId = (int)parameters["TeamId"];

                if (parameters.TryGetValue("Year", out object worldSeriesYear))
                    EditModel.WorldSeries.Year = (int?)worldSeriesYear;

                if (parameters.TryGetValue("ItemTypeId", out object worldSeriesItemTypeId))
                    EditModel.WorldSeries.ItemTypeId = (int?)worldSeriesItemTypeId;

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

        await Mediator.Send(command);

        Snackbar.Add("Project was saved successfully!", Severity.Success);

        await GetProjectMemorabiliaTeamUpdatedIds();
        await GetProjectPersonUpdatedIds();
    }

    protected async Task GetProjectMemorabiliaTeamUpdatedIds()
    {
        if (EditModel.MemorabiliaTeams.Count == 0)
            return;

        ProjectEditModel editModel = (await Mediator.Send(new GetProjectQuery(Id))).ToEditModel();

        EditModel.MemorabiliaTeams = editModel.MemorabiliaTeams;
    }

    protected async Task GetProjectPersonUpdatedIds()
    {
        if (EditModel.People.Count == 0)
            return;

        ProjectEditModel editModel = (await Mediator.Send(new GetProjectQuery(Id))).ToEditModel();

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
