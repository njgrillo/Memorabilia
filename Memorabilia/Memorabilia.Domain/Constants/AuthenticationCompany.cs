namespace Memorabilia.Domain.Constants;

public sealed class AuthenticationCompany : DomainItemConstant
{
    public static readonly AuthenticationCompany Beckett = new(2, "Beckett Authentication Services", "BAS");
    public static readonly AuthenticationCompany Fanatics = new(7, "Fanatics");
    public static readonly AuthenticationCompany JSA = new(1, "James Spence Authentication", "JSA", @"https://www.spenceloa.com/verify-authenticity/results?certificateNumber=");
    public static readonly AuthenticationCompany Leaf = new(9, "Leaf");
    public static readonly AuthenticationCompany MAB = new(10, "MAB Celebrity Services", "MAB");
    public static readonly AuthenticationCompany MajorLeagueBaseball = new(8, "Major League Baseball", "MLB");
    public static readonly AuthenticationCompany Other = new(12, "Other");
    public static readonly AuthenticationCompany Player = new(4, "Player Hologram");
    public static readonly AuthenticationCompany PSA = new(3, "Professional Sports Authenticator", "PSA", @"https://www.psacard.com/cert/");
    public static readonly AuthenticationCompany Radke = new(11, "Radke");
    public static readonly AuthenticationCompany Steiner = new(5, "Steiner");
    public static readonly AuthenticationCompany TriStar = new(6, "TriStar");
    public static readonly AuthenticationCompany USASportsMarketing = new(18, "USA Sports Marketing", "USA");

    public string WebsitePath { get; set; }

    public static readonly AuthenticationCompany[] All =
    {
        Beckett,
        Fanatics,
        JSA,
        Leaf,
        MAB,
        MajorLeagueBaseball,
        Other,
        Player,
        PSA,
        Radke,
        Steiner,
        TriStar,
        USASportsMarketing
    };

    public static readonly AuthenticationCompany[] BigThree =
    {
        Beckett,
        JSA,
        PSA
    };

    public static readonly AuthenticationCompany[] Navigatable =
    {
        JSA,
        PSA
    };

    private AuthenticationCompany(int id, 
                                  string name, 
                                  string abbreviation = null, 
                                  string websitePath = null) 
        : base(id, name, abbreviation) 
    {
        WebsitePath = websitePath;
    }

    public static AuthenticationCompany Find(int id)
        => All.SingleOrDefault(authenticationCompany => authenticationCompany.Id == id);
}
