namespace Memorabilia.Domain.Entities;

public class PrivateSigningItemTypeGroup : Framework.Library.Domain.Entity.DomainEntity
{
    public PrivateSigningItemTypeGroup() { }

    public PrivateSigningItemTypeGroup(decimal cost,
                                       int privateSigningItemGroupId)
    {
        Cost = cost;
        PrivateSigningItemGroupId = privateSigningItemGroupId;
    }

    public decimal Cost { get; private set; }

    public int PrivateSigningItemGroupId { get; private set; }
}
