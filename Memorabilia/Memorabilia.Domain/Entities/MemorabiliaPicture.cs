namespace Memorabilia.Domain.Entities;

public class MemorabiliaPicture : Framework.Library.Domain.Entity.DomainEntity
{
    public MemorabiliaPicture() { }

    public MemorabiliaPicture(int memorabiliaId, 
                              int orientationId,
                              bool matted, 
                              bool stretched, 
                              int? photoTypeId)
    {
        MemorabiliaId = memorabiliaId;
        OrientationId = orientationId; 
        Matted = matted;
        Stretched = stretched;
        PhotoTypeId = photoTypeId;
    }

    public bool Matted { get; set; }

    public int MemorabiliaId { get; private set; }

    public int OrientationId { get; private set; }

    public int? PhotoTypeId { get; private set; }

    public bool Stretched { get; private set; }

    public void Set(int orientationId, 
                    bool matted, 
                    bool stretched, 
                    int? photoTypeId)
    {
        OrientationId = orientationId;   
        Matted = matted;
        Stretched = stretched;
        PhotoTypeId = photoTypeId;
    }
}
