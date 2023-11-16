namespace Memorabilia.Domain.Constants;

public sealed class BammerType : DomainItemConstant
{
    public static readonly BammerType BabyBammer = new(1, "Baby Bammer");
    public static readonly BammerType Bammer = new(2, "Bammer");
    public static readonly BammerType BammBeano = new(3, "Bamm Beano");
    public static readonly BammerType BigBammer = new(4, "Big Bammer");
    public static readonly BammerType OpeningDay = new(5, "Opening Day Bammer");

    public static readonly BammerType[] All =
    [
        BabyBammer,
        Bammer,
        BammBeano,
        BigBammer,
        OpeningDay
    ];

    private BammerType(int id, string name, string abbreviation = null) 
        : base(id, name, abbreviation) { }

    public static BammerType Find(int id)
        => All.SingleOrDefault(bammerType => bammerType.Id == id);
}
