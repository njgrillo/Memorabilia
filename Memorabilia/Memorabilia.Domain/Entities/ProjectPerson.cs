﻿namespace Memorabilia.Domain.Entities;

public class ProjectPerson : Framework.Library.Domain.Entity.DomainEntity
{
    public ProjectPerson() { }

    public ProjectPerson(int projectId, 
                         int personId, 
                         int? itemTypeId, 
                         bool upgrade, 
                         int? rank, 
                         int? priorityTypeId,
                         int? projectStatusTypeId,
                         int? memorabiliaId,
                         int? autographId)
    {
        ProjectId = projectId;
        PersonId = personId;
        ItemTypeId = itemTypeId;
        Upgrade = upgrade;
        Rank = rank;
        PriorityTypeId = priorityTypeId;
        ProjectStatusTypeId = projectStatusTypeId;
        MemorabiliaId = memorabiliaId;
        AutographId = autographId;
    }

    public virtual Autograph Autograph { get; set; }

    public int? AutographId { get; set; }

    public int? ItemTypeId { get; set; }

    public int? MemorabiliaId { get; set; }

    public virtual Person Person { get; set; }

    public int PersonId { get; set; }   
    
    public int? PriorityTypeId { get; set; }

    public virtual Project Project { get; set; }
    
    public int ProjectId { get; set; }

    public int? ProjectStatusTypeId { get; set; }

    public int? Rank { get; set; }

    public bool Upgrade { get; set; }

    public void Set(int personId, 
        int? itemTypeId, 
        bool upgrade, 
        int? rank, 
        int? priorityTypeId,
        int? projectStatusTypeId,
        int? memorabliaId,
        int? autographId)
    {
        PersonId = personId;
        ItemTypeId = itemTypeId;
        Upgrade = upgrade;
        Rank = rank;
        PriorityTypeId = priorityTypeId;
        ProjectStatusTypeId = projectStatusTypeId;
        MemorabiliaId = memorabliaId;
        AutographId = autographId;
    }
}
