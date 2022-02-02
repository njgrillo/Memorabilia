using System;

namespace Memorabilia.Domain.Entities
{
    public abstract class Image : Framework.Domain.Entity.DomainEntity
    {
        public Image() { }

        public Image(string filePath, int imageTypeId, DateTime uploadDate)
        {
            FilePath = filePath;
            ImageTypeId = imageTypeId;
            UploadDate = uploadDate;
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
