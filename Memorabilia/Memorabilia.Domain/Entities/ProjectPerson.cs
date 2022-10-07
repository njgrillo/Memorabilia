namespace Memorabilia.Domain.Entities;

public class ProjectPerson : Framework.Library.Domain.Entity.DomainEntity
{
    public ProjectPerson() { }

    public ProjectPerson(int projectId, 
                         int personId, 
                         int? itemTypeId, 
                         bool upgrade, 
                         int? rank, 
                         int? priorityTypeId)
    {
        ProjectId = projectId;
        PersonId = personId;
        ItemTypeId = itemTypeId;
        Upgrade = upgrade;
        Rank = rank;
        PriorityTypeId = priorityTypeId;
    }

    public int? ItemTypeId { get; set; }

    public virtual Person Person { get; set; }

    public int PersonId { get; set; }   
    
    public int? PriorityTypeId { get; set; }
    
    public int ProjectId { get; set; }

    public int? Rank { get; set; }

    public bool Upgrade { get; set; }

    public void Set(int personId, int? itemTypeId, bool upgrade, int? rank, int? priorityTypeId)
    {
        PersonId = personId;
        ItemTypeId = itemTypeId;
        Upgrade = upgrade;
        Rank = rank;
        PriorityTypeId = priorityTypeId;
    }
}
