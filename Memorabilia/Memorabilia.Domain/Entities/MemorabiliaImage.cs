namespace Memorabilia.Domain.Entities;

public class MemorabiliaImage : Image
{
    public MemorabiliaImage() { }

    public MemorabiliaImage(int memorabiliaId, string filePath, int imageTypeId, DateTime uploadDate) : base(filePath, imageTypeId, uploadDate)
    {
        MemorabiliaId = memorabiliaId;
    }

    public int MemorabiliaId { get; private set; }
}
