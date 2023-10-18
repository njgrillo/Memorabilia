namespace Memorabilia.Domain.Entities;

public class MemorabiliaJerseyNumber : DomainIdEntity
{
    public MemorabiliaJerseyNumber() { }

    public MemorabiliaJerseyNumber(int memorabiliaId, int number)
    {
        MemorabiliaId = memorabiliaId;
        Number = number;
    }

    public int MemorabiliaId { get; private set; }

    public int Number { get; private set; }

    public void Set(int number)
    {
        Number = number;
    }
}
