namespace Memorabilia.Domain.Entities;

public class ProjectTeam : Entity
{
    public ProjectTeam() { }

    public ProjectTeam(int projectId,
        int  teamId,
        int? year)
    {
        ProjectId = projectId;
        TeamId = teamId;
        Year = year;
    }

    public int ProjectId { get; set; }

    public int TeamId { get; set; }

    public int? Year { get; set; }

    public void Set(int teamId, int? year)
    {
        TeamId = teamId;
        Year = year;
    }
}
