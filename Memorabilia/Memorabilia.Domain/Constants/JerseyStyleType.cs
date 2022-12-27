namespace Memorabilia.Domain.Constants;

public sealed class JerseyStyleType : DomainItemConstant
{
    public static readonly JerseyStyleType AllStar = new(5, "All Star");
    public static readonly JerseyStyleType Alternate = new(3, "Alternate");
    public static readonly JerseyStyleType Away = new(2, "Away");
    public static readonly JerseyStyleType Finals = new(7, "Finals");
    public static readonly JerseyStyleType Home = new(1, "Home");
    public static readonly JerseyStyleType Other = new(9, "Other");
    public static readonly JerseyStyleType ProBowl = new(6, "Pro Bowl");
    public static readonly JerseyStyleType SuperBowl = new(14, "Super Bowl");
    public static readonly JerseyStyleType TeamUSA = new(13, "Team USA", "USA");
    public static readonly JerseyStyleType Throwback = new(8, "Throwback");
    public static readonly JerseyStyleType Unknown = new(10, "Unknown");
    public static readonly JerseyStyleType WorldSeries = new(4, "World Series");    

    public static readonly JerseyStyleType[] All =
    {
        AllStar,
        Alternate,
        Away,
        Finals,
        Home,
        Other,
        ProBowl,
        SuperBowl,
        TeamUSA,
        Throwback,
        Unknown,        
        WorldSeries
    };

    private JerseyStyleType(int id, string name, string abbreviation = null) : base(id, name, abbreviation) { }

    public static JerseyStyleType Find(int id)
    {
        return All.SingleOrDefault(jerseyStyleType => jerseyStyleType.Id == id);
    }
}
