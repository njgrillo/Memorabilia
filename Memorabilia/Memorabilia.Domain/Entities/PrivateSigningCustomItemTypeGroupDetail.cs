namespace Memorabilia.Domain.Entities;

public class PrivateSigningCustomItemTypeGroupDetail : Framework.Library.Domain.Entity.DomainEntity
{
    public PrivateSigningCustomItemTypeGroupDetail() { }

    public PrivateSigningCustomItemTypeGroupDetail(decimal cost,
                                                   int privateSigningCustomItemTypeGroupId)
    {
        Cost = cost;
        PrivateSigningCustomItemTypeGroupId = privateSigningCustomItemTypeGroupId;
    }

    public decimal Cost { get; private set; }

    public virtual PrivateSigningCustomItemGroup PrivateSigningCustomItemGroup { get; private set; }

    public int PrivateSigningCustomItemTypeGroupId { get; private set; }
}
