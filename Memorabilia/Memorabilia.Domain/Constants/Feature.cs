namespace Memorabilia.Domain.Constants;

public sealed class Feature : DomainItemConstant
{
    public static readonly Feature BuySellTrade = new(1, "Buy/Sell/Trade", "Get access to buy, sell and trade memorabilia.");
    public static readonly Feature Collection = new(2, "Collections", "Create collections to track your memorablia by certain criteria.");
    public static readonly Feature Consignment = new(3, "Consignments", "Gain access to post and view cosignments.");
    public static readonly Feature ForumPost = new(4, "Post in Forum", "Gain access to post in the Forum section.");
    public static readonly Feature ForumView = new(5, "View Forum", "Access to view the Forum section.");
    public static readonly Feature Memorabilia = new(6, "Memorabilia Tracking", "Track your memorabilia collection in a very detailed fashion.");
    public static readonly Feature Message = new(7, "Messaging", "Allows you to send and receive messages to/from members.");
    public static readonly Feature PrivateSigning = new(8, "Private Signings", "Post and view private signings.");
    public static readonly Feature Project = new(9, "Projects", "Create and track progress of your projects using several provided templates.");
    public static readonly Feature SavedSearch = new(10, "Saved Searches", "Create and save searches for memorabilia and various platforms, including GraphinAllDay, eBay and others.");
    public static readonly Feature SignatureAuthentication = new(11, "Signature Authentication", "Get and give opinions on the authenticity of autographs.");
    public static readonly Feature SignatureIdentification = new(12, "Signature Identification", "Get and give help identifying autographs.");
    public static readonly Feature ThroughTheMail = new(13, "Through the Mail", "Search & Track autographs through the mail.", "TTM");
    public static readonly Feature Tools = new(14, "Tools", "A large selection of tools free for everyone to use.");    

    public static readonly Feature[] All =
    {
        BuySellTrade,
        Collection, 
        Consignment, 
        ForumPost,
        ForumView,
        Memorabilia, 
        Message, 
        PrivateSigning,
        Project,
        SavedSearch,
        SignatureAuthentication,
        SignatureIdentification,
        ThroughTheMail,
        Tools
    };

    public static readonly Feature[] Free =
    {
        ForumView,
        Tools
    };

    public static readonly Feature[] Tier1 =
    {
        BuySellTrade,
        Collection,
        ForumPost,
        ForumView,
        Memorabilia,
        Message,
        SavedSearch,
        SignatureAuthentication,
        SignatureIdentification,
        ThroughTheMail,
        Tools
    };

    public static readonly Feature[] Tier2 =
    {
        BuySellTrade,
        Collection,
        Consignment,
        ForumPost,
        ForumView,
        Memorabilia,
        Message,
        Project,
        SavedSearch,
        SignatureAuthentication,
        SignatureIdentification,
        ThroughTheMail,
        Tools
    };

    private Feature(int id, string name, string description, string abbreviation = null)
        : base(id, name, abbreviation) 
    { 
        Description = description;
    }

    public string Description { get; set; }

    public static Feature Find(int id)
        => All.SingleOrDefault(feature => feature.Id == id);
}
