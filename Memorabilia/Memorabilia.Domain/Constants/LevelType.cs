namespace Memorabilia.Domain.Constants;

public sealed class LevelType : DomainItemConstant
{
    public static readonly LevelType College = new(1, "College");
    public static readonly LevelType HighSchool = new(2, "High School");
    public static readonly LevelType Professional = new(3, "Professional");
    public static readonly LevelType Amateur = new(4, "Amateur");
    public static readonly LevelType Other = new(5, "Other");
    public static readonly LevelType None = new(6, "None");
    public static readonly LevelType Unknown = new(7, "Unknown");
    public static readonly LevelType TripleA = new(8, "Triple A", "AAA");
    public static readonly LevelType DoubleA = new(9, "Double A", "AA");
    public static readonly LevelType HighClassA = new(10, "High Class A", "A+");
    public static readonly LevelType ClassA = new(11, "Class A", "A");
    public static readonly LevelType Rookie = new(12, "Rookie");

    public static readonly LevelType[] All =
    {
        Amateur,
        ClassA,
        College,
        DoubleA,
        HighClassA,
        HighSchool,
        None,
        Other,
        Professional,
        Rookie,
        TripleA,
        Unknown
    };

    private LevelType(int id, string name, string abbreviation = null) 
        : base(id, name, abbreviation) { }

    public static LevelType Find(int id)
        => All.SingleOrDefault(levelType => levelType.Id == id);
}
