namespace Memorabilia.Domain.Constants;

public sealed class FigureSpecialtyType : DomainItemConstant
{
    public static readonly FigureSpecialtyType ClassicDoubles = new(1, "Classic Doubles");
    public static readonly FigureSpecialtyType CooperstownCollection = new(2, "Cooperstown Collection");
    public static readonly FigureSpecialtyType None = new(9, "None");
    public static readonly FigureSpecialtyType Other = new(8, "Other");
    public static readonly FigureSpecialtyType Unknown = new(7, "Unknown");

    public static readonly FigureSpecialtyType[] All =
    [
        ClassicDoubles,
        CooperstownCollection,
        None,
        Other,
        Unknown
    ];

    public static readonly FigureSpecialtyType[] FunkoPops =
    [
        
    ];

    public static readonly FigureSpecialtyType[] StartingLineups =
    [
        ClassicDoubles,
        CooperstownCollection
    ];

    private FigureSpecialtyType(int id, string name, string abbreviation = null) 
        : base(id, name, abbreviation) { }

    public static FigureSpecialtyType Find(int id)
        => All.SingleOrDefault(figureSpecialtyType => figureSpecialtyType.Id == id);

    public static FigureSpecialtyType[] GetAll(FigureType figureType)
    {
        if (figureType == FigureType.StartingLineup)
            return StartingLineups;

        if (figureType == FigureType.FunkoPop)
            return FunkoPops;

        return All;
    }
}
