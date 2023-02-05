namespace Memorabilia.Domain.Constants;

public sealed class GloveType : DomainItemConstant
{
    public static readonly GloveType Baseball = new(1, "Baseball Glove");
    public static readonly GloveType Batting = new(2, "Batting Glove");
    public static readonly GloveType Football = new(3, "Football Glove");
    public static readonly GloveType Hockey = new(4, "Hockey Glove");
    public static readonly GloveType Boxing = new(5, "Boxing Glove");
    public static readonly GloveType MMA = new(5, "MMA Glove", "MMA");
    public static readonly GloveType Other = new(10, "Other");
    public static readonly GloveType Soccer = new(11, "Soccer");

    public static readonly GloveType[] All =
    {
        Baseball,
        Batting,
        Boxing,
        Football,
        Hockey,            
        MMA,
        Other,
        Soccer
    };

    public static readonly GloveType[] BaseballTypes =
    {
        Baseball,
        Batting,
    };

    private GloveType(int id, string name, string abbreviation = null) 
        : base(id, name, abbreviation) { }

    public static GloveType Find(int id)
        => All.SingleOrDefault(gloveType => gloveType.Id == id);

    public static GloveType[] GetAll(params Sport[] sports)
    {
        var gloveTypes = new List<GloveType>(); 

        if (sports.Contains(Sport.Baseball))
            gloveTypes.AddRange(BaseballTypes);

        if (sports.Contains(Sport.Boxing))
            gloveTypes.Add(Boxing);

        if (sports.Contains(Sport.Football))
            gloveTypes.Add(Football);

        if (sports.Contains(Sport.Hockey))
            gloveTypes.Add(Hockey);

        if (sports.Contains(Sport.MixedMartialArts))
            gloveTypes.Add(MMA);

        if (sports.Contains(Sport.Soccer))
            gloveTypes.Add(Soccer);

        gloveTypes.Add(Other);

        return gloveTypes.OrderBy(x => x.Name)
                         .ToArray();
    }
}
