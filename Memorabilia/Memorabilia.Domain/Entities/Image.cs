﻿namespace Memorabilia.Domain.Entities;

public class Image : Framework.Library.Domain.Entity.DomainEntity
{
    public Image() { }

    public Image(string fileName, int imageTypeId, DateTime? uploadDate = null)
    {
        FileName = fileName;
        ImageTypeId = imageTypeId;

        if (uploadDate.HasValue)
            UploadDate = uploadDate.Value;
    }

    public string FileName { get; private set; }

    public int ImageTypeId { get; private set; }

    public DateTime UploadDate { get; private set; }

    public virtual void Set(int imageTypeId)
    {
        ImageTypeId = imageTypeId;
    }
}
