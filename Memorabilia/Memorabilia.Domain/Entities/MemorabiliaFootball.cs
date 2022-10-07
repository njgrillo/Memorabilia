namespace Memorabilia.Domain.Entities;

public class MemorabiliaFootball : Framework.Library.Domain.Entity.DomainEntity
{
    public MemorabiliaFootball() { }

    public MemorabiliaFootball(int memorabiliaId, int footballTypeId)
    {
        MemorabiliaId = memorabiliaId;
        FootballTypeId = footballTypeId;
    }

    public int FootballTypeId { get; private set; }

    public int MemorabiliaId { get; private set; }

    public void Set(int footballTypeId)
    {
        FootballTypeId = footballTypeId;
    }
}
