namespace Memorabilia.Domain.Entities
{
    public class Image : Framework.Library.Domain.Entity.DomainEntity
    {
        public Image() { }

        public Image(string filePath, int imageTypeId, DateTime? uploadDate = null)
        {
            FilePath = filePath;
            ImageTypeId = imageTypeId;

            if (uploadDate.HasValue)
                UploadDate = uploadDate.Value;
        }

        public string FilePath { get; private set; }

        public int ImageTypeId { get; private set; }

        public DateTime UploadDate { get; private set; }

        public virtual void Set(int imageTypeId)
        {
            ImageTypeId = imageTypeId;
        }
    }
}
