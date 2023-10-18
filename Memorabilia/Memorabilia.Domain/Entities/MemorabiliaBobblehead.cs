namespace Memorabilia.Domain.Entities;

public class MemorabiliaBobblehead : Entity
{
    public MemorabiliaBobblehead() { }

    public MemorabiliaBobblehead(int memorabiliaId, int? year, bool hasBox)
    {
        MemorabiliaId = memorabiliaId;
        HasBox = hasBox;
        Year = year;
    }

    public bool HasBox { get; private set; }

    public int MemorabiliaId { get; private set; }

    public int? Year { get; private set; }

    public void Set(int? year, bool hasBox)
    {
        HasBox = hasBox;
        Year = year;
    }
}

