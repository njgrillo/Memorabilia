namespace Memorabilia.Domain.Constants;

public sealed class Spot : DomainItemConstant
{
    public static readonly Spot BackCloth = new(24, "Back - On Cloth");
    public static readonly Spot BackCover = new(6, "Back Cover");
    public static readonly Spot BackNumber = new(21, "Back - On Number");
    public static readonly Spot BottomLeft = new(17, "Bottom - Facemask Facing Left");
    public static readonly Spot BottomRight = new(16, "Bottom - Facemask Facing Right");
    public static readonly Spot Crown = new(20, "Crown");
    public static readonly Spot FrontCloth = new(22, "Front - On Cloth");
    public static readonly Spot FrontCover = new(5, "Front Cover");
    public static readonly Spot FrontNumber = new(23, "Front - On Number");
    public static readonly Spot Inside = new(7, "Inside");
    public static readonly Spot LeftSide = new(39, "Left Side");
    public static readonly Spot MiddleLeft = new(19, "Middle - Facemask Facing Left");
    public static readonly Spot MiddleRight = new(18, "Middle - Facemask Facing Right");
    public static readonly Spot OnBack = new(10, "On Back");
    public static readonly Spot OnBase = new(29, "On Base");
    public static readonly Spot OnBear = new(28, "On Bear");
    public static readonly Spot OnBlade = new(37, "On Blade");
    public static readonly Spot OnBooklet = new(34, "On Booklet");
    public static readonly Spot OnBookplate = new(8, "On Bookplate");
    public static readonly Spot OnBox = new(31, "On Box");
    public static readonly Spot OnBrimBottomSide = new(42, "On Brim - Bottom Side");
    public static readonly Spot OnBrimTopSide = new(41, "On Brim - Top Side");
    public static readonly Spot OnCardboard = new(12, "On Cardboard");
    public static readonly Spot OnCD = new(35, "On CD");
    public static readonly Spot OnCloth = new(3, "On Cloth");
    public static readonly Spot OnFront = new(9, "On Front");
    public static readonly Spot OnHat = new(30, "On Hat");
    public static readonly Spot OnNumber = new(4, "On Number");        
    public static readonly Spot OnPackage = new(25, "On Package");        
    public static readonly Spot OnPlastic = new(11, "On Plastic");        
    public static readonly Spot OnPlasticTagProtector = new(27, "On Plastic Tag Protector");        
    public static readonly Spot OnStick = new(36, "On Stick");        
    public static readonly Spot OnTag = new(26, "On Tag");        
    public static readonly Spot RightSide = new (38, "Right Side");        
    public static readonly Spot SidePanel = new(2, "Side Panel");
    public static readonly Spot SweetSpot = new(1, "Sweet Spot");
    public static readonly Spot Top = new(40, "Top");
    public static readonly Spot TopLeft = new(15, "Top - Facemask Facing Left");
    public static readonly Spot TopRight = new(14, "Top - Facemask Facing Right");
    public static readonly Spot UnderLogo = new(13, "Under Logo");

    public static readonly Spot[] All =
    [
        BackCloth,
        BackCover,
        BackNumber,
        BottomLeft,
        BottomRight,
        Crown,
        FrontCloth,
        FrontCover,
        FrontNumber,
        Inside,
        LeftSide,
        MiddleLeft,
        MiddleRight,
        OnBack,
        OnBase,
        OnBear,
        OnBlade,
        OnBooklet,
        OnBookplate,
        OnBox,
        OnBrimBottomSide,
        OnBrimTopSide,
        OnCardboard,
        OnCD,
        OnCloth,
        OnFront,
        OnHat,
        OnNumber, 
        OnPackage,
        OnPlastic,
        OnPlasticTagProtector,
        OnStick,
        OnTag,
        RightSide,
        SidePanel,
        SweetSpot,
        Top,
        TopLeft,
        TopRight,
        UnderLogo
    ];

    private Spot(int id, string name, string abbreviation = null) 
        : base(id, name, abbreviation) { }

    public static Spot Find(int id)
        => All.SingleOrDefault(spot => spot.Id == id);

    public static Spot Find(string name)
        => All.SingleOrDefault(spot => spot.Name == name);
}
