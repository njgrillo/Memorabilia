namespace Memorabilia.Domain.Constants;

public sealed class Occupation : DomainItemConstant
{       
    public static readonly Occupation Actor = new(2, "Actor");
    public static readonly Occupation Actress = new(3, "Actress");
    public static readonly Occupation Athlete = new(1, "Athlete");
    public static readonly Occupation Broadcaster = new(5, "Broadcaster");
    public static readonly Occupation Celebrity = new(4, "Celebrity");
    public static readonly Occupation Coach = new(9, "Coach");
    public static readonly Occupation Comedian = new(6, "Comedian");
    public static readonly Occupation Commissioner = new(8, "Commissioner");        
    public static readonly Occupation LeaguePresident = new(12, "League President");       
    public static readonly Occupation Manager = new(7, "Manager");       

    public static readonly Occupation[] All =
    {
        Athlete,
        Actor,
        Actress,
        Broadcaster,
        Celebrity,  
        Coach,
        Comedian,
        Commissioner,
        LeaguePresident,
        Manager
    };

    public static readonly Occupation[] SportOccupations =
    {
        Athlete,
        Coach,
        Commissioner,
        LeaguePresident,
        Manager
    };

    private Occupation(int id, string name, string abbreviation = null) : base(id, name, abbreviation) { }

    public static Occupation Find(int id)
    {
        return All.SingleOrDefault(occupation => occupation.Id == id);
    }

    public static bool IsSportOccupation(int id)
    {
        return SportOccupations.Contains(Find(id));
    }
}
