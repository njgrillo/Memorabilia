namespace Memorabilia.Domain.Constants;

public sealed class Color : DomainItemConstant
{
    public static readonly Color Ash = new(8, "Ash");
    public static readonly Color Black = new(2, "Black");
    public static readonly Color Blonde = new(9, "Blonde");
    public static readonly Color Blue = new(1, "Blue");
    public static readonly Color Gold = new(4, "Gold");
    public static readonly Color Orange = new(6, "Orange");
    public static readonly Color Other = new(7, "Other");
    public static readonly Color Red = new(5, "Red");
    public static readonly Color Silver = new(3, "Silver");        
    public static readonly Color Unknown = new(14, "Unknown");        
    public static readonly Color White = new(10, "White");

    public static readonly Color[] All =
    {
        Ash,
        Black,
        Blonde,
        Blue,
        Gold,
        Orange,
        Other,
        Red,
        Silver,
        Unknown,
        White
    };

    public static readonly Color[] Autograph =
    {
        Black,
        Blue,
        Gold,
        Orange,
        Other,
        Red,
        Silver,
        Unknown,
        White
    };

    public static readonly Color[] Bat =
    {
        Ash,
        Black,
        Blonde,
        Blue,
        Gold,
        Other,
        Red,
        Unknown
    };

    private Color(int id, string name, string abbreviation = null) 
        : base(id, name, abbreviation) { }

    public static Color Find(int id)
        => All.SingleOrDefault(color => color.Id == id);

    public static Color Find(string name)
        => All.SingleOrDefault(color => color.Name == name);

    public static Color[] GetAll(ItemType itemType)
    {
        if (itemType == null)
            return All;

        if (itemType == ItemType.Bat)
            return Bat;

        return All;
    }
}
