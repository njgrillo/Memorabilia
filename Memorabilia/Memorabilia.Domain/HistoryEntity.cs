namespace Memorabilia.Domain;

public abstract class HistoryEntity : Entity
{
    public DateTime ValidFrom { get; }

    public DateTime ValidTo { get; }
}
