namespace Memorabilia.Domain.Constants;

public sealed class HelmetFinish : DomainItemConstant
{
    public static readonly HelmetFinish Blaze = new(6, "Blaze");
    public static readonly HelmetFinish Bronze = new(5, "Bronze");
    public static readonly HelmetFinish Chrome = new(2, "Chrome");
    public static readonly HelmetFinish ChromeTwentyFourKaratGoldPlatedFacemask = new(15, "Chrome 24k Gold Plated Facemask");
    public static readonly HelmetFinish Copper = new(14, "Copper");
    public static readonly HelmetFinish Custom = new(9, "Custom");
    public static readonly HelmetFinish Drip = new(10, "Drip");
    public static readonly HelmetFinish Flash = new(7, "Flash");
    public static readonly HelmetFinish Hydro = new(13, "Hydro");
    public static readonly HelmetFinish Ice = new(8, "Ice");
    public static readonly HelmetFinish Other = new(12, "Other");
    public static readonly HelmetFinish Pewter = new(1, "Pewter");
    public static readonly HelmetFinish Ripped = new(11, "Ripped");
    public static readonly HelmetFinish SterlingSilver = new(4, "Sterling Silver");
    public static readonly HelmetFinish TwentyFourKaratGoldPlated = new(3, "24k Gold Plated");

    public static readonly HelmetFinish[] All =
    {
        Blaze,
        Bronze,
        Chrome,
        ChromeTwentyFourKaratGoldPlatedFacemask,
        Copper,
        Custom,
        Drip,
        Flash,
        Hydro,
        Ice,
        Other,
        Pewter,
        Ripped,
        SterlingSilver,
        TwentyFourKaratGoldPlated
    };

    public static readonly HelmetFinish[] Project =
    {
        Pewter
    };

    private HelmetFinish(int id, string name, string abbreviation = null) 
        : base(id, name, abbreviation) { }

    public static HelmetFinish Find(int id)
        => All.SingleOrDefault(helmetFinish => helmetFinish.Id == id);
}
