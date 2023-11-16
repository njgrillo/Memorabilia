namespace Memorabilia.Domain.Constants;

public sealed class HelmetQualityType : DomainItemConstant
{
    public static readonly HelmetQualityType Authentic = new(1, "Authentic", "AUTH");
    public static readonly HelmetQualityType Replica = new(2, "Replica", "REP");

    public static readonly HelmetQualityType[] All =
    [
        Authentic,
        Replica
    ];

    private HelmetQualityType(int id, string name, string abbreviation) 
        : base(id, name, abbreviation) { }

    public static HelmetQualityType Find(int id)
        => All.SingleOrDefault(helmetQualityType => helmetQualityType.Id == id);
}
