namespace Memorabilia.Domain.Constants;

public sealed class FigureType : DomainItemConstant
{
    public static readonly FigureType StartingLineup = new(1, "Starting Lineup", "SLU");
    public static readonly FigureType FunkoPop = new(2, "Funko Pop", string.Empty);

    public static readonly FigureType[] All =
    {
        StartingLineup,
        FunkoPop
    };

    private FigureType(int id, string name, string abbreviation) : base(id, name, abbreviation) { }

    public static FigureType Find(int id)
    {
        return All.SingleOrDefault(figureType => figureType.Id == id);
    }
}
