namespace Memorabilia.Domain.Constants;

public sealed class PurchaseType : DomainItemConstant
{
    public static readonly PurchaseType Ebay = new(1, "eBay", string.Empty);
    public static readonly PurchaseType Amazon = new(2, "Amazon", string.Empty);
    public static readonly PurchaseType Other = new(3, "Other", string.Empty);
    public static readonly PurchaseType Retail = new(4, "Retail Store", string.Empty);
    public static readonly PurchaseType Facebook = new(5, "Facebook", string.Empty);

    public static readonly PurchaseType[] All =
    {
        Amazon,
        Ebay,
        Facebook,
        Other,
        Retail
    };

    private PurchaseType(int id, string name, string abbreviation) : base(id, name, abbreviation) { }

    public static PurchaseType Find(int id)
    {
        return All.SingleOrDefault(purchaseType => purchaseType.Id == id);
    }

    public static PurchaseType Find(string name)
    {
        return All.SingleOrDefault(purchaseType => purchaseType.Name == name);
    }
}
