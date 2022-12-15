namespace Memorabilia.Domain.Constants;

public sealed class GameStyleType : DomainItemConstant
{
    public static readonly GameStyleType GameUsed = new(1, "Game Used");
    public static readonly GameStyleType GameWorn = new(2, "Game Worn");
    public static readonly GameStyleType GameIssued = new(3, "Game Issued");
    public static readonly GameStyleType MatchUsed = new(7, "Match Used");
    public static readonly GameStyleType None = new(4, "None");
    public static readonly GameStyleType Other = new(5, "Other");
    public static readonly GameStyleType TournametUsed = new(6, "Tournamet Used");

    public static readonly GameStyleType[] All =
    {
        GameUsed,
        GameWorn,
        GameIssued,
        None,
        Other,
        MatchUsed,
        TournametUsed
    };

    public static readonly GameStyleType[] GameWorthly =
    {
        GameIssued,
        GameUsed,
        GameWorn,
        MatchUsed,
        TournametUsed
    };

    public static readonly GameStyleType[] NonWearableStyles =
    {
        GameUsed,
        GameIssued,
        MatchUsed,
        None,
        Other,
        TournametUsed
    };

    private GameStyleType(int id, string name, string abbreviation = null) : base(id, name, abbreviation) { }

    public static GameStyleType Find(int id)
    {
        return All.SingleOrDefault(gameStyleType => gameStyleType.Id == id);
    }

    public static GameStyleType[] GetAll(ItemType itemType)
    {
        if (ItemType.IsWearable(itemType))
            return All;

        return NonWearableStyles;
    }

    public static bool IsGameWorthly(GameStyleType gameStyleType)
    {
        return GameWorthly.Contains(gameStyleType);
    }
}
