namespace Memorabilia.Domain.Entities;

public class ProjectHallOfFame : Framework.Library.Domain.Entity.DomainEntity
{
    public ProjectHallOfFame() { }

    public ProjectHallOfFame(int projectId,
        int sportLeagueLevelId,
        int? year,
        int? itemTypeId)
    {
        ProjectId = projectId;
        ItemTypeId = itemTypeId;
        SportLeagueLevelId = sportLeagueLevelId;
        Year = year;
    }

    public int? ItemTypeId { get; set; }

    public int ProjectId { get; set; }

    public int SportLeagueLevelId { get; set; }

    public int? Year { get; set; }

    public void Set(int sportLeagueLevelId, int? year, int? itemTypeId)
    {
        ItemTypeId = itemTypeId;
        SportLeagueLevelId = sportLeagueLevelId;
        Year = year;
    }
}
