namespace Memorabilia.Domain.Constants;

public sealed class FigureType : DomainItemConstant
{    
    public static readonly FigureType FunkoPop = new(2, "Funko Pop");
    public static readonly FigureType None = new(8, "None");
    public static readonly FigureType Other = new(7, "Other");
    public static readonly FigureType StartingLineup = new(1, "Starting Lineup", "SLU");
    public static readonly FigureType Unknown = new(6, "Unknown");

    public static readonly FigureType[] All =
    {        
        FunkoPop,
        None,
        Other,
        StartingLineup,
        Unknown
    };

    private FigureType(int id, string name, string abbreviation = null) 
        : base(id, name, abbreviation) { }

    public static FigureType Find(int id)
        => All.SingleOrDefault(figureType => figureType.Id == id);
}
