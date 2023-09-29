namespace Memorabilia.Domain.Entities;

public class PrivateSigningPersonDetail : Framework.Library.Domain.Entity.DomainEntity
{
    public PrivateSigningPersonDetail() { }

    public PrivateSigningPersonDetail(string note,
                                      int? privateSigningCustomItemTypeGroupDetailId,
                                      int? privateSigningItemTypeGroupId,
                                      int privateSigningPersonId)
    {
        Note = note;
        PrivateSigningCustomItemTypeGroupDetailId = privateSigningCustomItemTypeGroupDetailId;
        PrivateSigningItemTypeGroupId = privateSigningItemTypeGroupId;
        PrivateSigningPersonId = privateSigningPersonId;
    }

    public string Note { get; private set; }

    public virtual PrivateSigningCustomItemTypeGroupDetail PrivateSigningCustomItemTypeGroupDetail { get; private set; }

    public int? PrivateSigningCustomItemTypeGroupDetailId { get; private set; }

    public virtual PrivateSigningItemTypeGroup PrivateSigningItemTypeGroup { get; private set; }

    public int? PrivateSigningItemTypeGroupId { get; private set; }

    public virtual PrivateSigningPerson PrivateSigningPerson { get; private set; }

    public int PrivateSigningPersonId { get; private set; }

    public void Set(string note)
    {
        Note = note;    
    }
}
