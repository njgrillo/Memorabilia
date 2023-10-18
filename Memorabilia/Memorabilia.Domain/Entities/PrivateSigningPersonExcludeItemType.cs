namespace Memorabilia.Domain.Entities;

public class PrivateSigningPersonExcludeItemType : Entity
{
    public PrivateSigningPersonExcludeItemType() { }

    public PrivateSigningPersonExcludeItemType(int itemTypeId,
                                               string note,
                                               int privateSigningPersonId)
    {
        ItemTypeId = itemTypeId;
        Note = note;
        PrivateSigningPersonId = privateSigningPersonId;
    }

    public int ItemTypeId { get; private set; }

    public string Note { get; private set; }

    public virtual PrivateSigningPerson PrivateSigningPerson { get; private set; }

    public int PrivateSigningPersonId { get; private set; }

    public void Set(string note)
    {
        Note = note;
    }
}
