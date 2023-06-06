﻿namespace Memorabilia.Application.Features.Project;

public class ProjectModel
{
    private readonly Entity.Project _project;

    public ProjectModel() { }

    public ProjectModel(Entity.Project project)
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

    public Entity.ProjectBaseball Baseball => _project.Baseball;

    public Entity.ProjectCard Card => _project.Card;

    public DateTime? EndDate => _project.EndDate;

    public string FormattedEndDate => EndDate?.ToString("MM/dd/yyyy");

    public string FormattedStartDate => StartDate?.ToString("MM/dd/yyyy");

    public Entity.ProjectHallOfFame HallOfFame => _project.HallOfFame;

    public Entity.ProjectHelmet Helmet => _project.Helmet;

    public int Id => _project.Id;

    public Entity.ProjectItem Item => _project.Item;

    public List<ProjectMemorabiliaTeamModel> MemorabiliaTeams { get; set; } = new();

    public string Name => _project.Name;

    public List<ProjectPersonModel> People { get; set; } = new();

    public int ProjectTypeId => _project.ProjectTypeId;

    public DateTime? StartDate => _project.StartDate;

    public Entity.ProjectTeam Team => _project.Team;

    public int UserId => _project.UserId;

    public Entity.ProjectWorldSeries WorldSeries => _project.WorldSeries;
}
