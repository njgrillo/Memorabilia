namespace Memorabilia.Domain.Constants;

public sealed class InternationalHallOfFameType : DomainItemConstant
{
    public static readonly InternationalHallOfFameType AustralianHallOfFame = new(9, "Australian Hall of Fame");
    public static readonly InternationalHallOfFameType CanadianHallOfFame = new(1, "Canadian Hall of Fame");
    public static readonly InternationalHallOfFameType CaribbeanHallOfFame = new(2, "Caribbean Hall of Fame");
    public static readonly InternationalHallOfFameType CubanHallOfFame = new(7, "Cuban Hall of Fame");
    public static readonly InternationalHallOfFameType JapaneseHallOfFame = new(3, "Japanese Hall of Fame");
    public static readonly InternationalHallOfFameType MexicanHallOfFame = new(4, "Mexican Hall of Fame");
    public static readonly InternationalHallOfFameType VenezuelanHallOfFame = new(8, "Venezuelan Hall of Fame");
    
    public static readonly InternationalHallOfFameType[] All =
    [
        AustralianHallOfFame,
        CanadianHallOfFame,
        CaribbeanHallOfFame,
        CubanHallOfFame,
        JapaneseHallOfFame,
        MexicanHallOfFame,
        VenezuelanHallOfFame
    ];

    private InternationalHallOfFameType(int id, string name) 
        : base(id, name) { }

    public static InternationalHallOfFameType Find(int id)
        => All.SingleOrDefault(internationalHallOfFameType => internationalHallOfFameType.Id == id);
}
