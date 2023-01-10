namespace Memorabilia.Domain.Constants;

public sealed class InternationalHallOfFameType : DomainItemConstant
{
    public static readonly InternationalHallOfFameType CanadianHallOfFame = new(1, "Canadian Hall of Fame");
    public static readonly InternationalHallOfFameType CaribbeanHallOfFame = new(2, "Caribbean Hall of Fame");
    public static readonly InternationalHallOfFameType CubanHallOfFame = new(7, "Cuban Hall of Fame");
    public static readonly InternationalHallOfFameType JapaneseHallOfFame = new(3, "Japanese Hall of Fame");
    public static readonly InternationalHallOfFameType MexicanHallOfFame = new(4, "Mexican Hall of Fame");
    
    public static readonly InternationalHallOfFameType[] All =
    {
        CanadianHallOfFame,
        CaribbeanHallOfFame,
        CubanHallOfFame,
        JapaneseHallOfFame,
        MexicanHallOfFame
    };

    private InternationalHallOfFameType(int id, string name) : base(id, name) { }

    public static InternationalHallOfFameType Find(int id)
    {
        return All.SingleOrDefault(internationalHallOfFameType => internationalHallOfFameType.Id == id);
    }
}
