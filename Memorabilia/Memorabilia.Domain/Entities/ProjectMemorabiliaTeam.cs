namespace Memorabilia.Domain.Entities;

public class ProjectMemorabiliaTeam : Entity
{
    public ProjectMemorabiliaTeam() { }

    public ProjectMemorabiliaTeam(int projectId,
                                  int teamId,
                                  int? itemTypeId,
                                  bool upgrade,
                                  int? rank,
                                  decimal? estimatedCost,
                                  int? priorityTypeId,
                                  int? projectStatusTypeId,
                                  int? memorabiliaId)
    {
        ProjectId = projectId;
        TeamId = teamId;
        ItemTypeId = itemTypeId;
        Upgrade = upgrade;
        Rank = rank;
        EstimatedCost = estimatedCost;
        PriorityTypeId = priorityTypeId;
        ProjectStatusTypeId = projectStatusTypeId;
        MemorabiliaId = memorabiliaId;
    }

    [Precision(12, 2)]
    public decimal? EstimatedCost { get; set; }

    public int? ItemTypeId { get; set; }

    public virtual Memorabilia Memorabilia { get; set; }

    public int? MemorabiliaId { get; set; }    

    public int? PriorityTypeId { get; set; }

    public virtual Project Project { get; set; }

    public int ProjectId { get; set; }

    public int? ProjectStatusTypeId { get; set; }

    public int? Rank { get; set; }

    public virtual Team Team { get; set; }

    public int TeamId { get; set; }

    public bool Upgrade { get; set; }

    public void Set(int teamId,
                    int? itemTypeId,
                    bool upgrade,
                    int? rank,
                    int? priorityTypeId,
                    int? projectStatusTypeId,
                    decimal? estimatedCost,
                    int? memorabliaId)
    {
        TeamId = teamId;
        ItemTypeId = itemTypeId;
        Upgrade = upgrade;
        Rank = rank;
        EstimatedCost = estimatedCost;
        PriorityTypeId = priorityTypeId;
        ProjectStatusTypeId = projectStatusTypeId;
        MemorabiliaId = memorabliaId;
    }
}
