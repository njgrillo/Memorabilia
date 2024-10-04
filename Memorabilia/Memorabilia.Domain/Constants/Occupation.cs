namespace Memorabilia.Domain.Constants;

public sealed class Occupation : DomainItemConstant
{       
    public static readonly Occupation Actor = new(2, "Actor");
    public static readonly Occupation Actress = new(3, "Actress");
    public static readonly Occupation Administrator = new(20, "Administrator");
    public static readonly Occupation Announcer = new(24, "Announcer");
    public static readonly Occupation Astronaut = new(19, "Astronaut");
    public static readonly Occupation Athlete = new(1, "Athlete");
    public static readonly Occupation Broadcaster = new(5, "Broadcaster");
    public static readonly Occupation Celebrity = new(4, "Celebrity");
    public static readonly Occupation Coach = new(9, "Coach");
    public static readonly Occupation Comedian = new(6, "Comedian");
    public static readonly Occupation Commissioner = new(8, "Commissioner");        
    public static readonly Occupation Executive = new(15, "Executive");        
    public static readonly Occupation FamousRelative = new(22, "Famous Relative");        
    public static readonly Occupation GeneralManager = new(14, "General Manager");        
    public static readonly Occupation Historian = new(27, "Historian");        
    public static readonly Occupation LeaguePresident = new(12, "League President");       
    public static readonly Occupation Manager = new(7, "Manager");       
    public static readonly Occupation Musician = new(18, "Musician");
    public static readonly Occupation Owner = new(13, "Owner");
    public static readonly Occupation Podcaster = new(29, "Podcaster");
    public static readonly Occupation Politician = new(16, "Politician");
    public static readonly Occupation President = new(17, "President");  
    public static readonly Occupation Singer = new(28, "Singer");  
    public static readonly Occupation SportsWriter = new(23, "Sports Writer");  
    public static readonly Occupation Statistician = new(25, "Statistician");  
    public static readonly Occupation Trainer = new(26, "Trainer");  
    public static readonly Occupation Umpire = new(21, "Umpire");  

    public static readonly Occupation[] All =
    [
        Actor,
        Actress,
        Administrator,
        Announcer,
        Astronaut,
        Athlete,
        Broadcaster,
        Celebrity,  
        Coach,
        Comedian,
        Commissioner,
        Executive,
        FamousRelative,
        GeneralManager,
        Historian,
        LeaguePresident,
        Manager,
        Musician,
        Owner,
        Podcaster,
        Politician,
        President,
        Singer,
        SportsWriter,
        Statistician,
        Trainer,
        Umpire
    ];

    public static Occupation[] BaseballOccupations
        => SportOccupations.Union([LeaguePresident, Manager, Umpire])
                           .ToArray();

    public static readonly Occupation[] SportOccupations =
    [
        Administrator,
        Announcer,
        Athlete,
        Broadcaster,
        Coach,
        Commissioner,
        Executive,
        FamousRelative,
        GeneralManager,
        Historian,
        Manager,
        Owner,
        SportsWriter,
        Statistician,
        Trainer
    ];

    private Occupation(int id, string name, string abbreviation = null)
        : base(id, name, abbreviation) { }

    public static Occupation Find(int id)
        => All.SingleOrDefault(occupation => occupation.Id == id);

    public static bool IsBaseballOccupation(int id)
        => BaseballOccupations.Contains(Find(id));

    public static bool IsSportOccupation(int id)
        => SportOccupations.Contains(Find(id));
}
