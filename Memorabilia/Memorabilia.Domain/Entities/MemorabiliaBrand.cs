namespace Memorabilia.Domain.Entities;

public class MemorabiliaBrand : DomainIdEntity
{
    public MemorabiliaBrand() { }

    public MemorabiliaBrand(int memorabiliaId, int brandId)
    {
        MemorabiliaId = memorabiliaId;
        BrandId = brandId;
    }

    public int BrandId { get; private set; }

    public int MemorabiliaId { get; private set; }

    public void Set(int brandId)
    {
        BrandId = brandId;
    }
}
