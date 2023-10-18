namespace Memorabilia.Domain.Entities;

public class MemorabiliaMagazine : Entity
{
    public MemorabiliaMagazine() { }

    public MemorabiliaMagazine(int memorabiliaId, int orientationId, DateTime? date, bool framed, bool matted)
    {
        MemorabiliaId = memorabiliaId;
        OrientationId = orientationId;
        Date = date;
        Framed = framed;
        Matted = matted;
    }

    public DateTime? Date { get; set; }

    public bool Framed { get; set; }

    public bool Matted { get; set; }

    public int MemorabiliaId { get; private set; }

    public int OrientationId { get; private set; }

    public void Set(int orientationId, DateTime? date, bool framed, bool matted)
    {
        OrientationId = orientationId;
        Date = date;
        Framed = framed;
        Matted = matted;
    }
}
