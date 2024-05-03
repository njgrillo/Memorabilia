namespace Memorabilia.Domain.Entities;

public class PromoterProvidedItem : Entity
{
    public PromoterProvidedItem() { }

    public PromoterProvidedItem(decimal cost,
                                int itemTypeId,
                                int promoterId,
                                decimal? shippingCost)
    {
        Cost = cost;
        ItemTypeId = itemTypeId;
        PromoterId = promoterId;
        ShippingCost = shippingCost;
    }

    [Precision(12, 2)]
    public decimal Cost { get; private set; }

    public virtual ItemType ItemType { get; private set; }

    public int ItemTypeId { get; private set; }

    public virtual User Promoter { get; private set; }

    public int PromoterId { get; private set; }

    [Precision(12, 2)]
    public decimal? ShippingCost { get; private set; }

    public void Set(decimal cost,
                    int itemTypeId,
                    decimal? shippingCost)
    {
        Cost = cost;
        ItemTypeId = itemTypeId;
        ShippingCost = shippingCost;
    }
}
