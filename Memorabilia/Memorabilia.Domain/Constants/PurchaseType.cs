namespace Memorabilia.Domain.Constants;

public sealed class PurchaseType : DomainItemConstant
{    
    public static readonly PurchaseType Amazon = new(2, "Amazon");
    public static readonly PurchaseType Ebay = new(1, "eBay");
    public static readonly PurchaseType Facebook = new(5, "Facebook");
    public static readonly PurchaseType Other = new(3, "Other");
    public static readonly PurchaseType Retail = new(4, "Retail Store");
    public static readonly PurchaseType Unknown = new(8, "Unknown");
    

    public static readonly PurchaseType[] All =
    {
        Amazon,
        Ebay,
        Facebook,
        Other,
        Retail,
        Unknown
    };

    private PurchaseType(int id, string name, string abbreviation = null) 
        : base(id, name, abbreviation) { }

    public static PurchaseType Find(int id)
    {
        return All.SingleOrDefault(purchaseType => purchaseType.Id == id);
    }

    public static PurchaseType Find(string name)
    {
        return All.SingleOrDefault(purchaseType => purchaseType.Name == name);
    }
}
