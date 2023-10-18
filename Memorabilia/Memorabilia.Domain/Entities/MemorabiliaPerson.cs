namespace Memorabilia.Domain.Entities;

public class MemorabiliaPerson : Entity
{
    public MemorabiliaPerson() { }

    public MemorabiliaPerson(int memorabiliaId, int personId)
    {
        MemorabiliaId = memorabiliaId;
        PersonId = personId;
    }

    public int MemorabiliaId { get; private set; }

    public virtual Person Person { get; set; }

    public int PersonId { get; private set; }

    public void Set(int personId)
    {
        PersonId = personId;
    }
}
