namespace Memorabilia.Domain.Constants;

public sealed class JerseyType : DomainItemConstant
{
    public static readonly JerseyType Stitched = new(1, "Stitched");
    public static readonly JerseyType ScreenPrint = new(2, "Screen Printed");
    public static readonly JerseyType Other = new(3, "Other");
    public static readonly JerseyType None = new(4, "None");
    public static readonly JerseyType Unknown = new(5, "Unknown");

    public static readonly JerseyType[] All =
    [
        Stitched,
        ScreenPrint,
        Other,
        None,
        Unknown
    ];

    private JerseyType(int id, string name, string abbreviation = null) 
        : base(id, name, abbreviation) { }

    public static JerseyType Find(int id)
        => All.SingleOrDefault(jerseyType => jerseyType.Id == id);
}
