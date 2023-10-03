namespace Memorabilia.Domain.Constants;

public class Permission : DomainItemConstant
{
    public static readonly Permission BuySellTrade = new(1, "BuySellTrade");
    public static readonly Permission Collection = new(2, "Collection");
    public static readonly Permission Consignment = new(3, "Consignment");
    public static readonly Permission Forum = new(4, "Forum");
    public static readonly Permission Memorabilia = new(5, "MemorabiliaTracking");
    public static readonly Permission Message = new(6, "Message");
    public static readonly Permission PrivateSigning = new(7, "PrivateSigning");
    public static readonly Permission Project = new(8, "Project");
    public static readonly Permission Search = new(9, "Search");
    public static readonly Permission SignatureAuthentication = new(10, "SignatureAuthentication");
    public static readonly Permission SignatureIdentification = new(11, "SignatureIdentification");
    public static readonly Permission ThroughTheMail = new(12, "ThroughTheMail");
    public static readonly Permission Tools = new(13, "Tools");

    public static readonly Permission[] All =
    {
        BuySellTrade,
        Collection,
        Consignment, 
        Forum, 
        Memorabilia, 
        Message, 
        PrivateSigning,
        Project,
        Search,
        SignatureAuthentication,            
        SignatureIdentification,
        ThroughTheMail,
        Tools
    };

    private Permission(int id, string name, string abbreviation = null)
        : base(id, name, abbreviation) { }

    public static Permission Find(int id)
        => All.SingleOrDefault(permission => permission.Id == id);

    public static Permission FindByName(string name)
        => All.SingleOrDefault(permission => permission.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
}
