namespace Memorabilia.Domain.Constants;

public sealed class ForumCategory : DomainItemConstant
{
    public static readonly ForumCategory AddressRequests = new(1, "Address Requests", canBeSportRelated: true);
    public static readonly ForumCategory Buy = new(2, "Buy", canBeSportRelated: true);
    public static readonly ForumCategory Consignments = new(3, "Consignments", canBeSportRelated: true);
    public static readonly ForumCategory InPersonGraphin = new (4, "In Person Graphin'", canBeSportRelated: true);
    public static readonly ForumCategory Miscellaneous = new(5, "Miscellaneous", canBeSportRelated: false);
    public static readonly ForumCategory PrivateSignings = new(6, "Private Signings", canBeSportRelated: true);
    public static readonly ForumCategory Resources = new(7, "Resources", canBeSportRelated: false);
    public static readonly ForumCategory Sell = new(8, "Sell", canBeSportRelated: true);
    public static readonly ForumCategory SigningInterest = new(9, "Signing Interest", canBeSportRelated: true);
    public static readonly ForumCategory ThroughTheMail = new(10, "Through the Mail (TTM)", canBeSportRelated: true);
    public static readonly ForumCategory TipsAndTricks = new(12, "Tips & Tricks", canBeSportRelated: false);
    public static readonly ForumCategory Trade = new(11, "Trade", canBeSportRelated: true);    
    public static readonly ForumCategory Vouches = new(13, "Vouches", canBeSportRelated: false);

    public bool CanBeSportRelated { get; private set; }

    public static readonly ForumCategory[] All =
    [
        AddressRequests,
        Buy,
        Consignments,
        InPersonGraphin,
        Miscellaneous,
        PrivateSignings,
        Resources,
        Sell,
        SigningInterest,
        ThroughTheMail,
        TipsAndTricks,
        Trade,
        Vouches
    ];

    public static readonly ForumCategory[] SportRelated =
    [
        AddressRequests,
        Buy,
        Consignments,
        InPersonGraphin,
        PrivateSignings,
        Sell,
        SigningInterest,
        ThroughTheMail,
        Trade       
    ];

    private ForumCategory(int id, string name, bool canBeSportRelated, string abbreviation = null)
        : base(id, name, abbreviation) 
    { 
        CanBeSportRelated = canBeSportRelated;
    }

    public static bool CanHaveSport(int id)
        => SportRelated.Any(forumCategory => forumCategory.Id == id);

    public static ForumCategory Find(int id)
        => All.SingleOrDefault(forumCategory => forumCategory.Id == id);
}
