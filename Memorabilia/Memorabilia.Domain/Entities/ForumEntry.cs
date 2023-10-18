namespace Memorabilia.Domain.Entities;

public class ForumEntry : DomainIdEntity
{
    public ForumEntry() { }

    public ForumEntry(DateTime createdDate,
                      int createdByUserId,
                      int forumTopicId,
                      string message)
    {
        CreatedDate = createdDate;
        CreatedByUserId = createdByUserId;
        ForumTopicId = forumTopicId;
        Message = message;
    }

    public DateTime CreatedDate { get; private set; }

    public virtual User CreatedByUser { get; private set; }

    public int CreatedByUserId { get; private set; }

    public virtual ForumTopic ForumTopic { get; private set; }

    public int ForumTopicId { get; private set; }

    public virtual List<ForumEntryImage> Images { get; private set; }
        = new();

    public string Message { get; private set; }

    public DateTime? ModifiedDate { get; private set; }

    public int Rank { get; private set; }

    public virtual List<ForumEntryUserRank> RankedUsers { get; private set; }
        = new();

    public void AddImage(byte[] image)
    {
        Images.Add(new ForumEntryImage(Id, image));
    }

    public void DecreaseRank(int userId)
    {
        Rank = Math.Max(0, Rank - 1);        

        RankedUsers.RemoveAll(rankedUser => rankedUser.User.Id == userId);
    }

    public void IncreaseRank(int userId)
    {
        Rank++;

        RankedUsers.Add(new ForumEntryUserRank(Id, userId));
    }

    public void RemoveImage(int forumEntryImageId)
    {
        Images.RemoveAll(forumEntryImage => forumEntryImage.Id == forumEntryImageId);
    }

    public void Set(DateTime modifiedDate,
                    string message)
    {
        ModifiedDate = modifiedDate;
        Message = message;
    }    
}
