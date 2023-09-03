namespace Memorabilia.Application.Features.Project;

public class ProjectEditModel : EditModel
{
    public ProjectEditModel() { }

    public ProjectEditModel(ProjectModel model)
    {
        EndDate = model.EndDate;
        Id = model.Id;
        Name = model.Name;

        People = model.People
                      .Select(person => new ProjectPersonEditModel(person))
                      .ToList();

        MemorabiliaTeams = model.MemorabiliaTeams
                                .Select(item => new ProjectMemorabiliaTeamEditModel(item))
                                .ToList();

        StartDate = model.StartDate;
        UserId = model.UserId;
        ProjectType = Constant.ProjectType.Find(model.ProjectTypeId);

        if (MemorabiliaTeams.Any() && MemorabiliaTeams.Select(item => item.ItemTypeId).Distinct().Count() == 1)
            ItemTypeId = MemorabiliaTeams.First().ItemTypeId;

        if (People.Any() && People.Select(person => person.ItemTypeId).Distinct().Count() == 1)
            ItemTypeId = People.First().ItemTypeId;

        SetProjectDetailsParameters(model);
    }

    public Entity.ProjectBaseball Baseball { get; set; } 
        = new();

    public Entity.ProjectCard Card { get; set; } 
        = new();

    public double CompletedMemorabiliaTeamCount
        => MemorabiliaTeams.Where(person => person.PriorityTypeId != Constant.PriorityType.Watching.Id)
                           .Count(item => item.ProjectStatusTypeId == Constant.ProjectStatusType.Completed.Id);

    public double CompletedPersonCount
        => People.Where(person => person.PriorityTypeId != Constant.PriorityType.Watching.Id)
                 .Count(person => person.ProjectStatusTypeId == Constant.ProjectStatusType.Completed.Id);

    public DateTime? EndDate { get; set; }

    public override string ExitNavigationPath 
        => "Projects";

    public Entity.ProjectHallOfFame HallOfFame { get; set; } 
        = new();

    public bool HasDefaultItemType 
        => ItemTypeId > 0;

    public Entity.ProjectHelmet Helmet { get; set; } 
        = new();

    public string ImageFileName 
        => Constant.ImageFileName.ProjectTypes;

    public Entity.ProjectItem Item { get; set; } 
        = new();

    public override string ItemTitle 
        => "Project";

    public int ItemTypeId { get; set; }

    public List<ProjectMemorabiliaTeamEditModel> MemorabiliaTeams { get; set; } 
        = new();

    public override string PageTitle 
        => "Project";

    public List<ProjectPersonEditModel> People { get; set; } 
        = new();

    public Constant.ProjectType ProjectType { get; set; }

    public override string RoutePrefix 
        => "Projects";

    public DateTime? StartDate { get; set; }

    public double StatusPercentage
    {
        get
        {
            if (Id == 0)
                return 0;

            if (Constant.ProjectType.IsPersonProject(ProjectType))
                return People.Count > 0
                    ? (int)((double)(CompletedPersonCount / People.Count) * 100)
                    : 0;

            if (Constant.ProjectType.IsTeamProject(ProjectType))
                return MemorabiliaTeams.Count > 0
                    ? (int)((double)(CompletedMemorabiliaTeamCount / MemorabiliaTeams.Count) * 100)
                    : 0;

            return 0;
        }
    }

    public Entity.ProjectTeam Team { get; set; } 
        = new();

    public int UserId { get; set; }

    public Entity.ProjectWorldSeries WorldSeries { get; set; } 
        = new();

    protected void SetProjectDetailsParameters(ProjectModel model)
    {
        switch (ProjectType.ToString())
        {
            case "BaseballType":
                Baseball.BaseballTypeId = model.Baseball.BaseballTypeId;
                Baseball.TeamId = model.Baseball.TeamId;
                Baseball.Year = model.Baseball.Year;
                break;
            case "Card":
                Card.BrandId = model.Card.BrandId;
                Card.TeamId = model.Card.TeamId;
                Card.Year = model.Card.Year;
                break;
            case "HallofFame":
                HallOfFame.SportLeagueLevelId = model.HallOfFame.SportLeagueLevelId;
                HallOfFame.ItemTypeId = model.HallOfFame.ItemTypeId;
                HallOfFame.Year = model.HallOfFame.Year;
                break;
            case "HelmetType":
                Helmet.HelmetTypeId = model.Helmet.HelmetTypeId;
                Helmet.HelmetFinishId = model.Helmet.HelmetFinishId;
                Helmet.SizeId = model.Helmet.SizeId; 
                break;
            case "ItemType":
                Item.ItemTypeId = model.Item.ItemTypeId;
                Item.MultiSignedItem = model.Item.MultiSignedItem;
                break;
            case "Team":
                Team.TeamId = model.Team.TeamId;
                Team.Year = model.Team.Year;
                break;
            case "WorldSeries":
                WorldSeries.TeamId = model.WorldSeries.TeamId;
                WorldSeries.ItemTypeId = model.WorldSeries.ItemTypeId;
                WorldSeries.Year = model.WorldSeries.Year;
                break;
            default:
                throw new NotImplementedException();
        }
    }
}
