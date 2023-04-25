namespace Memorabilia.Domain.Constants;

public sealed class Occupation : DomainItemConstant
{       
    public static readonly Occupation Actor = new(2, "Actor");
    public static readonly Occupation Actress = new(3, "Actress");
    public static readonly Occupation Administrator = new(20, "Administrator");
    public static readonly Occupation Astronaut = new(19, "Astronaut");
    public static readonly Occupation Athlete = new(1, "Athlete");
    public static readonly Occupation Broadcaster = new(5, "Broadcaster");
    public static readonly Occupation Celebrity = new(4, "Celebrity");
    public static readonly Occupation Coach = new(9, "Coach");
    public static readonly Occupation Comedian = new(6, "Comedian");
    public static readonly Occupation Commissioner = new(8, "Commissioner");        
    public static readonly Occupation Executive = new(15, "Executive");        
    public static readonly Occupation GeneralManager = new(14, "General Manager");        
    public static readonly Occupation LeaguePresident = new(12, "League President");       
    public static readonly Occupation Manager = new(7, "Manager");       
    public static readonly Occupation Musician = new(18, "Musician");
    public static readonly Occupation Owner = new(13, "Owner");
    public static readonly Occupation Politician = new(16, "Politician");
    public static readonly Occupation President = new(17, "President");  
    public static readonly Occupation Umpire = new(21, "Umpire");  

    public static readonly Occupation[] All =
    {
        Actor,
        Actress,
        Administrator,
        Astronaut,
        Athlete,
        Broadcaster,
        Celebrity,  
        Coach,
        Comedian,
        Commissioner,
        Executive,
        GeneralManager,
        LeaguePresident,
        Manager,
        Musician,
        Owner,
        Politician,
        President,
        Umpire
    };

    public static Occupation[] BaseballOccupations
        => SportOccupations.Union(new[] { LeaguePresident, Manager, Umpire })
                           .ToArray();

    public static readonly Occupation[] SportOccupations =
    {
        Administrator,
        Athlete,
        Broadcaster,
        Coach,
        Commissioner,
        Executive,
        GeneralManager,
        Owner
    };

    private Occupation(int id, string name, string abbreviation = null)
        : base(id, name, abbreviation) { }

    public static Occupation Find(int id)
        => All.SingleOrDefault(occupation => occupation.Id == id);

    public static bool IsBaseballOccupation(int id)
        => BaseballOccupations.Contains(Find(id));

    public static bool IsBaseballOccupation(Occupation occupation)
        => BaseballOccupations.Contains(occupation);

    public static bool IsSportOccupation(int id)
        => SportOccupations.Contains(Find(id));

    public static bool IsSportOccupation(Occupation occupation)
        => SportOccupations.Contains(occupation);
}
