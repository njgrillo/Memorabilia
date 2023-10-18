namespace Memorabilia.Domain.Entities;

public class PrivateSigningCustomItemTypeGroupDetail : Entity
{
    public PrivateSigningCustomItemTypeGroupDetail() { }

    public PrivateSigningCustomItemTypeGroupDetail(decimal cost,
                                                   int privateSigningCustomItemTypeGroupId,
                                                   decimal? shippingCost)
    {
        Cost = cost;
        PrivateSigningCustomItemTypeGroupId = privateSigningCustomItemTypeGroupId;
        ShippingCost = shippingCost;
    }

    public decimal Cost { get; private set; }

    public virtual PrivateSigningCustomItemGroup PrivateSigningCustomItemGroup { get; private set; }

    public int PrivateSigningCustomItemTypeGroupId { get; private set; }

    public decimal? ShippingCost { get; private set; }
}
