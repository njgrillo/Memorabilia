namespace Memorabilia.Domain.Entities;

public class PrivateSigningItemTypeGroup : Framework.Library.Domain.Entity.DomainEntity
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

    public decimal Cost { get; private set; }

    public int PrivateSigningItemGroupId { get; private set; }

    public decimal? ShippingCost { get; private set; }

    public void Set(decimal cost,
                    decimal? shippingCost)
    {
        Cost = cost;
        ShippingCost = shippingCost;
    }
}
