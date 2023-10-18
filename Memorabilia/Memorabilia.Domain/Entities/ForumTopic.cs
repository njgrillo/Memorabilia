namespace Memorabilia.Domain.Entities;

public class ForumTopic : DomainIdEntity
{
    public ForumTopic() { }

    public ForumTopic(DateTime createdDate, 
                      int createdByUserId, 
                      int forumCategoryId, 
                      int id,
                      DateTime? modifiedDate, 
                      int? sportId,
                      string subject,
                      string username)
    {
        CreatedDate = createdDate;
        CreatedByUserId = createdByUserId;
        ForumCategoryId = forumCategoryId;
        Id = id;
        ModifiedDate = modifiedDate;
        SportId = sportId;
        Subject = subject;

        CreatedByUser = new User(CreatedByUserId, username);
    }

    public ForumTopic(DateTime createdDate,
                      int createdByUserId,
                      int forumCategoryId,
                      int? sportId,
                      string subject)
    {
        CreatedDate = createdDate;
        CreatedByUserId = createdByUserId;
        ForumCategoryId = forumCategoryId;
        SportId = sportId;
        Subject = subject;
    }

    public virtual List<ForumTopicUserBookmark> Bookmarks { get; set; }
        = new();

    public DateTime CreatedDate { get; private set; }

    public virtual User CreatedByUser { get; private set; }

    public int CreatedByUserId { get; private set; }

    public virtual List<ForumEntry> Entries { get; set; }
        = new();

    public int ForumCategoryId { get; private set; }

    public DateTime? ModifiedDate { get; private set; }

    public virtual Sport Sport { get; private set; }

    public int? SportId { get; private set; }

    public string Subject { get; private set; }    

    public void AddEntry(string message, 
                         DateTime createdDate, 
                         int createdByUserId)
    {
        Entries.Add(new ForumEntry(createdDate, createdByUserId, Id, message));
    }

    public void DecreaseEntryRank(int id,
                                  int userId)
    {
        ForumEntry entry = Entries.Single(item => item.Id == id);

        entry.DecreaseRank(userId);
    }

    public void IncreaseEntryRank(int id,
                                  int userId)
    {
        ForumEntry entry = Entries.Single(item => item.Id == id);

        entry.IncreaseRank(userId);
    }

    public void Set(DateTime modifiedDate,
                    int? sportId,
                    string subject)
    {
        ModifiedDate = modifiedDate;
        SportId = sportId;
        Subject = subject;
    }

    public void SetBookmark(int userId)
    {
        ForumTopicUserBookmark bookmark = Bookmarks.FirstOrDefault(item => item.UserId == userId);

        if (bookmark != null) 
        { 
            Bookmarks.Remove(bookmark);
            return;
        }

        Bookmarks.Add(new ForumTopicUserBookmark(Id, userId));
    }

    public void SetEntry(int id,
                         string message,
                         DateTime modifiedDate)
    {
        ForumEntry entry = Entries.Single(item => item.Id == id);

        entry.Set(modifiedDate, message);
    }  
}
