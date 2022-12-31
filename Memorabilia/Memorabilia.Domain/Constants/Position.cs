namespace Memorabilia.Domain.Constants;

public sealed class Position : DomainItemConstant
{
    public static readonly Position Catcher = new(2, "Catcher", "C");
    public static readonly Position Center = new(22, "Center", "C");
    public static readonly Position CenterField = new(7, "Center Field", "CF");
    public static readonly Position Cornerback = new(21, "Cornerback", "CB");
    public static readonly Position DefensiveEnd = new(19, "Defensive End", "DE");
    public static readonly Position DefensiveTackle = new(24, "Defensive Tackle", "DT");
    public static readonly Position DesignatedHitter = new(10, "Designated Hitter", "DH");
    public static readonly Position End = new(30, "End");
    public static readonly Position FirstBase = new(3, "First Base", "1B");
    public static readonly Position Fullback = new(17, "Fullback", "FB");
    public static readonly Position Guard = new(18, "Guard", "G");
    public static readonly Position Halfback = new(16, "Halfback", "HB");
    public static readonly Position Infielder = new(32, "Infielder", "IF");
    public static readonly Position Kicker = new(27, "Kicker", "K");
    public static readonly Position LeftField = new(8, "Left Field", "LF");
    public static readonly Position Linebacker = new(28, "Linebacker");
    public static readonly Position LongSnapper = new(25, "Long Snapper");
    public static readonly Position OffensiveTackle = new (23, "Offensive Tackle", "OT");
    public static readonly Position Outfielder = new (29, "Outfielder");
    public static readonly Position Pitcher = new(1, "Pitcher", "P");
    public static readonly Position Punter = new(26, "Punter", "P");
    public static readonly Position Quarterback = new(12, "Quarterback", "QB");
    public static readonly Position RightField = new(9, "Right Field", "RF");
    public static readonly Position Runningback = new(13, "Running back", "RB");
    public static readonly Position Safety = new(20, "Safety", "S");
    public static readonly Position SecondBase = new(4, "Second Base", "2B");
    public static readonly Position Shortstop = new(5, "Shortstop", "SS");
    public static readonly Position SplitEnd = new (31, "Split End");
    public static readonly Position ThirdBase = new(6, "Third Base", "3B");
    public static readonly Position TightEnd = new(15, "Tight End", "TE");
    public static readonly Position Utility = new(11, "Utility", "U");
    public static readonly Position WideReceiver = new(14, "Wide Receiver", "WR");

    public static readonly Position[] All =
    {
        Catcher,
        Center,
        CenterField,
        Cornerback,
        DefensiveEnd,
        DefensiveTackle,
        DesignatedHitter,
        End,
        FirstBase,
        Fullback,
        Guard,
        Halfback,
        Infielder,
        Kicker,
        LeftField,
        Linebacker,
        LongSnapper,
        OffensiveTackle,
        Outfielder,
        Pitcher,
        Punter,
        Quarterback,
        RightField, 
        Runningback,
        Safety,
        SecondBase,
        Shortstop,
        SplitEnd,
        ThirdBase,
        TightEnd,
        Utility,
        WideReceiver
    };

    public static readonly Position[] Baseball =
    {
        Catcher,
        CenterField,
        DesignatedHitter,
        FirstBase,
        Infielder,
        LeftField,
        Outfielder,
        Pitcher,
        RightField,
        SecondBase,
        Shortstop,
        ThirdBase,
        Utility
    };

    public static readonly Position[] Football =
    {
        Center,
        Cornerback,
        DefensiveEnd,
        DefensiveTackle,
        End,
        Fullback,
        Guard,
        Halfback,
        Kicker,
        Linebacker,
        LongSnapper,
        OffensiveTackle,
        Punter,
        Quarterback,
        Runningback,
        Safety,
        SplitEnd,
        TightEnd,
        WideReceiver
    };

    private Position(int id, string name, string abbreviation = null) : base(id, name, abbreviation) { }

    public static Position Find(int id)
    {
        return All.SingleOrDefault(Position => Position.Id == id);
    }

    public static Position[] GetAll(params Sport[] sports)
    {
        if (!sports.Any())
            return All;

        var positions = new List<Position>();

        if (sports.Any(sport => sport == Sport.Baseball))
            positions.AddRange(Baseball);

        if (sports.Any(sport => sport == Sport.Football))
            positions.AddRange(Football);

        return positions.OrderBy(position => position.Name).ToArray();
    }
}
