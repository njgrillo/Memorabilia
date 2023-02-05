namespace Memorabilia.Domain.Constants;

public sealed class JerseyQualityType : DomainItemConstant
{
    public static readonly JerseyQualityType Authentic = new(1, "Authentic");
    public static readonly JerseyQualityType Replica = new(2, "Replica");
    public static readonly JerseyQualityType China = new(3, "China");
    public static readonly JerseyQualityType Custom = new(4, "Custom");
    public static readonly JerseyQualityType Other = new(5, "Other");
    public static readonly JerseyQualityType Unknown = new(6, "Unknown");

    public static readonly JerseyQualityType[] All =
    {
        Authentic,
        China,
        Custom,
        Other,
        Replica,            
        Unknown
    };

    private JerseyQualityType(int id, string name, string abbreviation = null) 
        : base(id, name, abbreviation) { }

    public static JerseyQualityType Find(int id)
        => All.SingleOrDefault(jerseyQualityType => jerseyQualityType.Id == id);
}
