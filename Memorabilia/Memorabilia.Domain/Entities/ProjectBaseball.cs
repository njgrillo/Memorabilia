namespace Memorabilia.Domain.Entities;

public class ProjectBaseball : Framework.Library.Domain.Entity.DomainEntity
{
	public ProjectBaseball() { }

    public ProjectBaseball(int projectId, 
        int baseballTypeId,
        int? teamId,
        int? year) 
    { 
        ProjectId = projectId;
        BaseballTypeId = baseballTypeId;
        TeamId = teamId;
        Year = year;
    }

    public int BaseballTypeId { get; set; }

    public int ProjectId { get; set; }

    public int? TeamId { get; set; }

    public int? Year { get; set; }

    public void Set(int baseballTypeId, int? teamId, int? year)
    {
        BaseballTypeId = baseballTypeId;
        TeamId = teamId;
        Year = year;
    }
}
