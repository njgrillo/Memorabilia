namespace Memorabilia.Domain.Entities;

public class CollectionMemorabilia : Entity
{
    public CollectionMemorabilia() { }

    public CollectionMemorabilia(int collectionId,
        int memorabiliaId)
    {
        CollectionId = collectionId;
        MemorabiliaId = memorabiliaId;
    }

    public virtual Collection Collection { get; set; }

    public int CollectionId { get; set; }

    public virtual Memorabilia Memorabilia { get; set; }

    public int MemorabiliaId { get; set; }

    public void Set(int memorabiliaId)
    {
        MemorabiliaId = memorabiliaId;
    }
}
