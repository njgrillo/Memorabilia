namespace Memorabilia.Domain.Entities;

public class ProjectWorldSeries : Framework.Library.Domain.Entity.DomainEntity
{
    public ProjectWorldSeries() { }

    public ProjectWorldSeries(int projectId,
        int teamId,
        int? year,
        int? itemTypeId)
    {
        ProjectId = projectId;
        ItemTypeId = itemTypeId;
        TeamId = teamId;
        Year = year;
    }

    public int? ItemTypeId { get; set; }

    public int ProjectId { get; set; }

    public int TeamId { get; set; }

    public int? Year { get; set; }

    public void Set(int teamId, int? year, int? itemTypeId)
    {
        ItemTypeId = itemTypeId;
        TeamId = teamId;
        Year = year;
    }
}
