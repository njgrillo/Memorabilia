namespace Memorabilia.Domain.Entities
{
    public class AutographImage : Image
    {
        public AutographImage() { }

        public AutographImage(int autographId, string filePath, int imageTypeId, DateTime uploadDate) : base(filePath, imageTypeId, uploadDate)
        {
            AutographId = autographId;
        }

        public int AutographId { get; private set; }
    }
}
