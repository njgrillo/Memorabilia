namespace Memorabilia.Domain.Constants;

public sealed class FootballType : DomainItemConstant
{
    public static readonly FootballType Duke = new(1, "Duke");
    public static readonly FootballType DukeReplica = new(2, "Duke Replica");
    public static readonly FootballType Commemorative = new(3, "Commemorative");
    public static readonly FootballType Other = new(4, "Other");

    public static readonly FootballType[] All =
    {
        Commemorative,
        Duke,
        DukeReplica,            
        Other
    };

    public static readonly FootballType[] GameWorthly =
    {
        Duke,
        Other
    };

    private FootballType(int id, string name, string abbreviation = null) 
        : base(id, name, abbreviation) { }

    public static FootballType Find(int id)
        => All.SingleOrDefault(footballType => footballType.Id == id);

    public static FootballType[] GetAll(GameStyleType gameStyleType)
    {
        if (gameStyleType == null || gameStyleType == GameStyleType.None)
            return All;

        return GameWorthly;
    }

    public static bool IsGameWorthly(FootballType footballType)
        => GameWorthly.Contains(footballType);
}
