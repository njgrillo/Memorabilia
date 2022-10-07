namespace Memorabilia.Domain.Constants;

public sealed class HelmetType : DomainItemConstant
{
    public static readonly HelmetType F7 = new(5, "F7", string.Empty);
    public static readonly HelmetType Flex = new(1, "Flex", string.Empty);
    public static readonly HelmetType Other = new(6, "Other", string.Empty);
    public static readonly HelmetType Revolution = new(4, "Revolution", string.Empty);
    public static readonly HelmetType Speed = new(3, "Speed", string.Empty);        
    public static readonly HelmetType VSR4 = new(7, "VSR4", string.Empty);        

    public static readonly HelmetType[] All =
    {
        F7,
        Flex,
        Other,
        Revolution,
        Speed,
        VSR4
    };

    public static readonly HelmetType[] GameWorthly =
    {
        F7,
        Flex,
        Other,
        Revolution,
        Speed,
        VSR4
    };

    private HelmetType(int id, string name, string abbreviation) : base(id, name, abbreviation) { }

    public static HelmetType Find(int id)
    {
        return All.SingleOrDefault(helmetType => helmetType.Id == id);
    }

    public static HelmetType[] GetAll(GameStyleType gameStyleType)
    {
        if (gameStyleType == null || gameStyleType == GameStyleType.None)
            return All;

        return GameWorthly;
    }

    public static bool IsGameWorthly(HelmetType helmetType)
    {
        return GameWorthly.Contains(helmetType);
    }
}
