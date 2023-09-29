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

    public virtual PrivateSigningCustomItemTypeGroup PrivateSigningCustomItemTypeGroup { get; private set; }

    public int PrivateSigningCustomItemTypeGroupId { get; private set; }
}
