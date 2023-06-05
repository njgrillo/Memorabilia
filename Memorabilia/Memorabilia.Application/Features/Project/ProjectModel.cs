using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Project;

public class ProjectModel
{
    private readonly Domain.Entities.Project _project;

    public ProjectModel() { }

    public ProjectModel(Domain.Entities.Project project)
    {
        _project = project;

        MemorabiliaTeams = _project.MemorabiliaTeams.Any()
            ? _project.MemorabiliaTeams
                      .Select(item => new ProjectMemorabiliaTeamModel(item))
                      .ToList()
            : new();

        People = _project.People.Any()
            ? _project.People
                      .Select(person => new ProjectPersonModel(person))
                      .ToList()
            : new();
    }

    public ProjectBaseball Baseball => _project.Baseball;

    public ProjectCard Card => _project.Card;

    public DateTime? EndDate => _project.EndDate;

    public string FormattedEndDate => EndDate?.ToString("MM/dd/yyyy");

    public string FormattedStartDate => StartDate?.ToString("MM/dd/yyyy");

    public ProjectHallOfFame HallOfFame => _project.HallOfFame;

    public ProjectHelmet Helmet => _project.Helmet;

    public int Id => _project.Id;

    public ProjectItem Item => _project.Item;

    public List<ProjectMemorabiliaTeamModel> MemorabiliaTeams { get; set; } = new();

    public string Name => _project.Name;

    public List<ProjectPersonModel> People { get; set; } = new();

    public int ProjectTypeId => _project.ProjectTypeId;

    public DateTime? StartDate => _project.StartDate;

    public ProjectTeam Team => _project.Team;

    public int UserId => _project.UserId;

    public ProjectWorldSeries WorldSeries => _project.WorldSeries;
}
