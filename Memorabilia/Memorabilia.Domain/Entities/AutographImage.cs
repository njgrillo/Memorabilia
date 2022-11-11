namespace Memorabilia.Domain.Entities;

public class AutographImage : Image
{
    public AutographImage() { }

    public AutographImage(int autographId, string fileName, int imageTypeId, DateTime uploadDate) : base(fileName, imageTypeId, uploadDate)
    {
        AutographId = autographId;
    }

    public int AutographId { get; private set; }
}
