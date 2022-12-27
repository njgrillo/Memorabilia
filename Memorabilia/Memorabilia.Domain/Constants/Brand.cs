namespace Memorabilia.Domain.Constants;

public sealed class Brand : DomainItemConstant
{
    public static readonly Brand Adidas = new(4, "Adidas");
    public static readonly Brand Beckett = new(14, "Beckett");
    public static readonly Brand Callaway = new(24, "Callaway");
    public static readonly Brand CCM = new(26, "CCM");
    public static readonly Brand Champion = new(1032, "Champion");
    public static readonly Brand Easton = new(1026, "Easton");
    public static readonly Brand Fender = new(22, "Fender");
    public static readonly Brand Fotoball = new(27, "Fotoball");
    public static readonly Brand Funko = new(19, "Funko Inc.");
    public static readonly Brand Hasbro = new(18, "Hasbro");
    public static readonly Brand HighSchoolDayz = new(1030, "High School Dayz");
    public static readonly Brand Kenner = new(17, "Kenner");
    public static readonly Brand LouisvilleSlugger = new(1025, "Louisville Slugger", "LS");
    public static readonly Brand Majestic = new(5, "Majestic");
    public static readonly Brand MitchellAndNess = new(1022, "Mitchell & Ness", "MN");
    public static readonly Brand Muslady = new(21, "Muslady");
    public static readonly Brand NewEra = new(25, "New Era");
    public static readonly Brand Nike = new(2, "Nike");
    public static readonly Brand None = new(8, "None");
    public static readonly Brand Other = new(7, "Other");
    public static readonly Brand Photofile = new(12, "Photofile");
    public static readonly Brand PlayersOfTheCentury = new (1034, "Players of the Century");
    public static readonly Brand Rawlings = new(1, "Rawlings");
    public static readonly Brand Reach = new(28, "Reach");
    public static readonly Brand Reebok = new(3, "Reebok", "RBK");  
    public static readonly Brand Riddell = new(11, "Riddell");
    public static readonly Brand Russell = new(1028, "Russell");
    public static readonly Brand Salvino = new(20, "Salvino");
    public static readonly Brand Spalding = new(10, "Spalding");  
    public static readonly Brand Spinneybeck = new(9, "Spinneybeck");  
    public static readonly Brand SportsIllustrated = new(13, "Sports Illustrated", "SI");
    public static readonly Brand Starter = new(1035, "Starter");
    public static readonly Brand TeamSpirit = new (1033, "Team Spirit");
    public static readonly Brand TeamworkAthleticApparel = new(1027, "Teamwork Athelic Apparel");
    public static readonly Brand Titleist = new(23, "Titleist");
    public static readonly Brand Topps = new(15, "Topps");  
    public static readonly Brand Unknown = new(1031, "Unknown");  
    public static readonly Brand UpperDeck = new(16, "Upper Deck", "UD");  
    public static readonly Brand XavierProline = new(1029, "Xavier Proline");  
    public static readonly Brand Wilson = new(6, "Wilson");

    public static readonly Brand[] All =
    {
        Adidas,
        Beckett,
        Callaway,
        CCM,
        Champion,
        Easton,
        Fender,
        Fotoball,
        Funko,
        Hasbro,
        HighSchoolDayz,
        Kenner,
        LouisvilleSlugger,
        Majestic,
        MitchellAndNess,
        Muslady,
        NewEra,
        Nike,
        None,
        Other,
        Photofile,
        PlayersOfTheCentury,
        Rawlings,
        Reach,
        Reebok,
        Riddell,
        Russell,
        Salvino,
        Spalding,
        Spinneybeck,
        SportsIllustrated,
        Starter,
        TeamSpirit,
        TeamworkAthleticApparel,
        Titleist,
        Topps,
        Unknown,
        UpperDeck,
        XavierProline,
        Wilson
    };

    public static readonly Brand[] GameWorthlyBaseballBrand =
    {
        Rawlings,
        Reach,
        Spalding
    };

    private Brand(int id, string name, string abbreviation = null) : base(id, name, abbreviation) { }

    public static Brand Find(int id)
    {
        return All.SingleOrDefault(brand => brand.Id == id);
    }

    public static Brand Find(string name)
    {
        return All.SingleOrDefault(brand => brand.Name == name);
    }

    public static bool IsGameWorthlyBaseballBrand(int id)
    {
        return GameWorthlyBaseballBrand.Contains(Find(id));
    }

    public static bool IsGameWorthlyBaseballBrand(Brand brand)
    {
        return GameWorthlyBaseballBrand.Contains(brand);
    }
}
