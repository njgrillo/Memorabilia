namespace Memorabilia.Domain.Entities;

public class MemorabiliaImage : Image
{
    public MemorabiliaImage() { }

    public MemorabiliaImage(int memorabiliaId, string fileName, int imageTypeId, DateTime uploadDate) : base(fileName, imageTypeId, uploadDate)
    {
        MemorabiliaId = memorabiliaId;
    }

    public int MemorabiliaId { get; private set; }
}
