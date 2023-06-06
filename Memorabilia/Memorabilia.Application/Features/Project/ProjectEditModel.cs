namespace Memorabilia.Application.Features.Project;

public class ProjectEditModel : EditModel
{
    public ProjectEditModel() { }

    public ProjectEditModel(ProjectModel viewModel)
    {
        EndDate = viewModel.EndDate;
        Id = viewModel.Id;
        Name = viewModel.Name;
        People = viewModel.People
                          .Select(person => new ProjectPersonEditModel(person))
                          .ToList();
        MemorabiliaTeams = viewModel.MemorabiliaTeams
                                    .Select(item => new ProjectMemorabiliaTeamEditModel(item))
                                    .ToList();
        StartDate = viewModel.StartDate;
        UserId = viewModel.UserId;
        ProjectType = Constant.ProjectType.Find(viewModel.ProjectTypeId);

        if (MemorabiliaTeams.Any() && MemorabiliaTeams.Select(item => item.ItemTypeId).Distinct().Count() == 1)
            ItemTypeId = MemorabiliaTeams.First().ItemTypeId;

        if (People.Any() && People.Select(person => person.ItemTypeId).Distinct().Count() == 1)
            ItemTypeId = People.First().ItemTypeId;

        SetProjectDetailsParameters(viewModel);
    }

    public Entity.ProjectBaseball Baseball { get; set; } = new();

    public Entity.ProjectCard Card { get; set; } = new();

    public double CompletedMemorabiliaTeamCount
        => MemorabiliaTeams.Count(item => item.ProjectStatusTypeId == Constant.ProjectStatusType.Completed.Id);

    public double CompletedPersonCount
        => People.Count(person => person.ProjectStatusTypeId == Constant.ProjectStatusType.Completed.Id);

    public DateTime? EndDate { get; set; }

    public override string ExitNavigationPath => "Projects";

    public Entity.ProjectHallOfFame HallOfFame { get; set; } = new();

    public bool HasDefaultItemType => ItemTypeId > 0;

    public Entity.ProjectHelmet Helmet { get; set; } = new();

    public string ImageFileName 
        => Constant.ImageFileName.ProjectTypes;

    public Entity.ProjectItem Item { get; set; } = new();

    public override string ItemTitle => "Project";

    public int ItemTypeId { get; set; }

    public List<ProjectMemorabiliaTeamEditModel> MemorabiliaTeams { get; set; } = new();

    public override string PageTitle => "Project";

    public List<ProjectPersonEditModel> People { get; set; } = new();

    public Constant.ProjectType ProjectType { get; set; }

    public override string RoutePrefix => "Projects";

    public DateTime? StartDate { get; set; }

    public double StatusPercentage
    {
        get
        {
            if (Id == 0)
                return 0;

            if (ProjectType == Constant.ProjectType.BaseballType)
                return People.Count > 0
                    ? (int)((double)(CompletedPersonCount / People.Count) * 100)
                    : 0;

            if (ProjectType == Constant.ProjectType.HelmetType)
                return MemorabiliaTeams.Count > 0
                    ? (int)((double)(CompletedMemorabiliaTeamCount / MemorabiliaTeams.Count) * 100)
                    : 0;

            return 0;
        }
    }

    public Entity.ProjectTeam Team { get; set; } = new();

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "User Id is required.")]
    public int UserId { get; set; }

    public Entity.ProjectWorldSeries WorldSeries { get; set; } = new();

    protected void SetProjectDetailsParameters(ProjectModel viewModel)
    {
        switch (ProjectType.ToString())
        {
            case "BaseballType":
                Baseball.BaseballTypeId = viewModel.Baseball.BaseballTypeId;
                Baseball.TeamId = viewModel.Baseball.TeamId;
                Baseball.Year = viewModel.Baseball.Year;
                break;
            case "Card":
                Card.BrandId = viewModel.Card.BrandId;
                Card.TeamId = viewModel.Card.TeamId;
                Card.Year = viewModel.Card.Year;
                break;
            case "HallofFame":
                HallOfFame.SportLeagueLevelId = viewModel.HallOfFame.SportLeagueLevelId;
                HallOfFame.ItemTypeId = viewModel.HallOfFame.ItemTypeId;
                HallOfFame.Year = viewModel.HallOfFame.Year;
                break;
            case "HelmetType":
                Helmet.HelmetTypeId = viewModel.Helmet.HelmetTypeId;
                Helmet.HelmetFinishId = viewModel.Helmet.HelmetFinishId;
                Helmet.SizeId = viewModel.Helmet.SizeId; 
                break;
            case "ItemType":
                Item.ItemTypeId = viewModel.Item.ItemTypeId;
                Item.MultiSignedItem = viewModel.Item.MultiSignedItem;
                break;
            case "Team":
                Team.TeamId = viewModel.Team.TeamId;
                Team.Year = viewModel.Team.Year;
                break;
            case "WorldSeries":
                WorldSeries.TeamId = viewModel.WorldSeries.TeamId;
                WorldSeries.ItemTypeId = viewModel.WorldSeries.ItemTypeId;
                WorldSeries.Year = viewModel.WorldSeries.Year;
                break;
            default:
                break;
        }
    }
}
