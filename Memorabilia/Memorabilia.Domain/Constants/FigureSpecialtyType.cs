namespace Memorabilia.Domain.Constants;

public sealed class FigureSpecialtyType : DomainItemConstant
{
    public static readonly FigureSpecialtyType ClassicDoubles = new(1, "Classic Doubles", string.Empty);
    public static readonly FigureSpecialtyType CooperstownCollection = new(2, "Cooperstown Collection", string.Empty);

    public static readonly FigureSpecialtyType[] All =
    {
        ClassicDoubles,
        CooperstownCollection
    };

    public static readonly FigureSpecialtyType[] FunkoPops =
    {
        
    };

    public static readonly FigureSpecialtyType[] StartingLineups =
    {
        ClassicDoubles,
        CooperstownCollection
    };

    private FigureSpecialtyType(int id, string name, string abbreviation) : base(id, name, abbreviation) { }

    public static FigureSpecialtyType Find(int id)
    {
        return All.SingleOrDefault(figureSpecialtyType => figureSpecialtyType.Id == id);
    }

    public static FigureSpecialtyType[] GetAll(FigureType figureType)
    {
        if (figureType == FigureType.StartingLineup)
            return StartingLineups;

        if (figureType == FigureType.FunkoPop)
            return FunkoPops;

        return All;
    }
}
