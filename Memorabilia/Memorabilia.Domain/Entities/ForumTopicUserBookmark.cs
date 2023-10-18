namespace Memorabilia.Domain.Entities;

public class ForumTopicUserBookmark : Entity
{
    public ForumTopicUserBookmark() { }

    public ForumTopicUserBookmark(int forumTopicId,
                                  int userId)
    {
        ForumTopicId = forumTopicId;
        UserId = userId;
    }

    public int ForumTopicId { get; private set; }

    public virtual User User { get; private set; }

    public int UserId { get; private set; }
}
