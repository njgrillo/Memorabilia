﻿namespace Memorabilia.Domain.Entities;

public class ForumEntryImage : Entity
{
    public ForumEntryImage() { }

    public ForumEntryImage(int forumEntryId,
                           byte[] imageData)
    {
        ForumEntryId = forumEntryId;
        ImageData = imageData;   
    }

    public int ForumEntryId { get; set; }

    public byte[] ImageData { get; set; }
}
