namespace Memorabilia.Domain.Constants;

public sealed class HelpItem : DomainItemConstant
{
    public static readonly HelpItem Home = new(1, "Home");
    public static readonly HelpItem Consignments = new(2, "Consignments");
    public static readonly HelpItem MyStuff = new(3, "My Stuff", hasChildren: true);
    public static readonly HelpItem MyStuffCollections = new(4, "Collections", MyStuff);
    public static readonly HelpItem MyStuffDashboard = new(5, "Dashboard", MyStuff);
    public static readonly HelpItem MyStuffFeeback = new(6, "Feedback", MyStuff);
    public static readonly HelpItem MyStuffForSale = new(7, "For Sale", MyStuff);
    public static readonly HelpItem MyStuffForTrade = new(8, "For Trade", MyStuff);
    public static readonly HelpItem MyStuffForumBookmarks = new(9, "Forum Bookmarks", MyStuff);
    public static readonly HelpItem MyStuffMemorabilia = new(10, "Memorabilia", MyStuff);
    public static readonly HelpItem MyStuffMessages = new(11, "Messages", MyStuff);
    public static readonly HelpItem MyStuffOffers = new(12, "Offers", MyStuff);
    public static readonly HelpItem MyStuffPrivateSignings = new(13, "Private Signings", MyStuff);
    public static readonly HelpItem MyStuffProjects = new(14, "Projects", MyStuff);
    public static readonly HelpItem MyStuffProposedTrades = new(15, "Proposed Trades", MyStuff);
    public static readonly HelpItem MyStuffSavedSearches = new(16, "Saved Searches", MyStuff);
    public static readonly HelpItem MyStuffSettings = new(17, "Settings", MyStuff);
    public static readonly HelpItem MyStuffThroughTheMail = new(18, "Through the Mail", MyStuff);
    public static readonly HelpItem MyStuffTransactions = new(19, "Transactions", MyStuff);
    public static readonly HelpItem Forums = new(20, "Forums");
    public static readonly HelpItem Memorabilia = new(21, "Memorabilia");
    public static readonly HelpItem PrivateSignings = new(22, "Private Signings");
    public static readonly HelpItem SignatureAuthentication = new(23, "Signature Authentication");
    public static readonly HelpItem SignatureIdentification = new(24, "Signature Identification");
    public static readonly HelpItem Tools = new(25, "Tools", hasChildren: true);
    public static readonly HelpItem ToolsPersonProfile = new(26, "Person Profile", Tools);
    public static readonly HelpItem ToolsBaseball = new(27, "Baseball", Tools);
    public static readonly HelpItem ToolsBasketball = new(28, "Basketball", Tools);
    public static readonly HelpItem ToolsFootball = new(29, "Football", Tools);
    public static readonly HelpItem ToolsHockey = new(30, "Hockey", Tools);
    public static readonly HelpItem ToolsMultiSport= new(31, "Multi Sport", Tools);

    public static readonly HelpItem[] All =
    {
        Home,
        Consignments,
        MyStuff,
        MyStuffCollections,
        MyStuffDashboard,
        MyStuffFeeback,
        MyStuffForSale,
        MyStuffForTrade,
        MyStuffForumBookmarks,
        MyStuffMemorabilia,
        MyStuffMessages,
        MyStuffOffers,
        MyStuffPrivateSignings,
        MyStuffProjects,
        MyStuffProposedTrades,
        MyStuffSavedSearches,
        MyStuffSettings,
        MyStuffThroughTheMail,
        MyStuffTransactions,
        Forums,
        Memorabilia,
        PrivateSignings,
        SignatureAuthentication,
        SignatureIdentification,
        Tools,
        ToolsPersonProfile,
        ToolsBaseball,
        ToolsBasketball,
        ToolsFootball,
        ToolsHockey,
        ToolsMultiSport
    };

    public static readonly HelpItem[] Parents =
    {
        Home,
        Consignments,
        MyStuff,
        Forums,
        Memorabilia,
        PrivateSignings,
        SignatureAuthentication,
        SignatureIdentification,
        Tools
    };

    public bool HasChildren { get; private set; } 

    public HelpItem Parent { get; private set; }

    private HelpItem(int id, string name, bool? hasChildren = false)
        : base(id, name) 
    {
        HasChildren = hasChildren ?? false;
    }

    private HelpItem(int id, string name, HelpItem parent)
        : base(id, name)
    {
        Parent = parent;
    }

    public static HelpItem[] GetChildren(HelpItem helpItem)
        => All.Where(item => item.Parent != null && item.Parent.Id == helpItem.Id)
              .ToArray();

    public override string ToString()
        => Parent != null 
            ? $"{Parent.Name.Replace(" ", "")}{Name.Replace(" ", "")}"
            : Name.Replace(" ", "");
}
