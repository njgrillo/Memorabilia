namespace Memorabilia.Domain.Constants;

public sealed class FootballType : DomainItemConstant
{
    public static readonly FootballType Duke = new(1, "Duke", string.Empty);
    public static readonly FootballType DukeReplica = new(2, "Duke Replica", string.Empty);
    public static readonly FootballType Commemorative = new(3, "Commemorative", string.Empty);
    public static readonly FootballType Other = new(4, "Other", string.Empty);

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

    private FootballType(int id, string name, string abbreviation) : base(id, name, abbreviation) { }

    public static FootballType Find(int id)
    {
        return All.SingleOrDefault(footballType => footballType.Id == id);
    }

    public static FootballType[] GetAll(GameStyleType gameStyleType)
    {
        if (gameStyleType == null || gameStyleType == GameStyleType.None)
            return All;

        return GameWorthly;
    }

    public static bool IsGameWorthly(FootballType footballType)
    {
        return GameWorthly.Contains(footballType);
    }
}
