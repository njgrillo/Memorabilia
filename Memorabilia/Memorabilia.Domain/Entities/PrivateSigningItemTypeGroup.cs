namespace Memorabilia.Domain.Entities;

public class PrivateSigningItemTypeGroup : Entity
{
    public PrivateSigningItemTypeGroup() { }

    public PrivateSigningItemTypeGroup(decimal cost,
                                       int privateSigningItemGroupId,
                                       decimal? shippingCost)
    {
        Cost = cost;
        PrivateSigningItemGroupId = privateSigningItemGroupId;
        ShippingCost = shippingCost;
    }

    [Precision(12, 2)]
    public decimal Cost { get; private set; }

    public int PrivateSigningItemGroupId { get; private set; }

    [Precision(12, 2)]
    public decimal? ShippingCost { get; private set; }

    public void Set(decimal cost,
                    decimal? shippingCost)
    {
        Cost = cost;
        ShippingCost = shippingCost;
    }
}
