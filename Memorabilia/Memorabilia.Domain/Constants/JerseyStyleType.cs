namespace Memorabilia.Domain.Constants;

public sealed class JerseyStyleType : DomainItemConstant
{
    public static readonly JerseyStyleType Home = new(1, "Home", string.Empty);
    public static readonly JerseyStyleType Away = new(2, "Away", string.Empty);
    public static readonly JerseyStyleType Alternate = new(3, "Alternate", string.Empty);
    public static readonly JerseyStyleType WorldSeries = new(4, "World Series", string.Empty);
    public static readonly JerseyStyleType AllStar = new(5, "All Star", string.Empty);
    public static readonly JerseyStyleType ProBowl = new(6, "Pro Bowl", string.Empty);
    public static readonly JerseyStyleType Finals = new(7, "Finals", string.Empty);
    public static readonly JerseyStyleType Throwback = new(8, "Throwback", string.Empty);
    public static readonly JerseyStyleType Other = new(9, "Other", string.Empty);
    public static readonly JerseyStyleType Unknown = new(10, "Unknown", string.Empty);

    public static readonly JerseyStyleType[] All =
    {
        AllStar,
        Alternate,
        Away,
        Finals,
        Home,
        Other,
        ProBowl,
        Throwback,
        Unknown,
        WorldSeries
    };

    private JerseyStyleType(int id, string name, string abbreviation) : base(id, name, abbreviation) { }

    public static JerseyStyleType Find(int id)
    {
        return All.SingleOrDefault(jerseyStyleType => jerseyStyleType.Id == id);
    }
}
