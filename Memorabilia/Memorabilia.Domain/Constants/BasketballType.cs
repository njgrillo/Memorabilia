namespace Memorabilia.Domain.Constants;

public sealed class BasketballType : DomainItemConstant
{
    public static readonly BasketballType Official = new(1, "Official");
    public static readonly BasketballType Finals = new(2, "Finals");
    public static readonly BasketballType Commemorative = new(3, "Commemorative");
    public static readonly BasketballType Other = new(4, "Other");
    public static readonly BasketballType None = new(5, "None");

    public static readonly BasketballType[] All =
    [
        Commemorative,
        Finals,
        Official,
        None,
        Other
    ];

    public static readonly BasketballType[] GameWorthly =
    [
        Finals,
        Official
    ];

    private BasketballType(int id, string name, string abbreviation = null) 
        : base(id, name, abbreviation) { }    

    public static BasketballType Find(int id)
        => All.SingleOrDefault(basketballType => basketballType.Id == id);

    public static BasketballType[] GetAll(GameStyleType gameStyleType)
    {
        if (gameStyleType == null || gameStyleType == GameStyleType.None)
            return All;

        return GameWorthly;
    }
}
