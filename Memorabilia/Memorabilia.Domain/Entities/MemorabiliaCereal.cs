namespace Memorabilia.Domain.Entities;

public class MemorabiliaCereal : Entity
{
    public MemorabiliaCereal() { }

    public MemorabiliaCereal(int memorabiliaId, int? cerealTypeId)
    {
        MemorabiliaId = memorabiliaId;
        CerealTypeId = cerealTypeId;
    }

    public int? CerealTypeId { get; private set; }

    public int MemorabiliaId { get; private set; }

    public void Set(int? cerealTypeId)
    {
        CerealTypeId = cerealTypeId;
    }
}
