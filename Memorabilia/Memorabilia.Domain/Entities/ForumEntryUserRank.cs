namespace Memorabilia.Domain.Entities;

public class ForumEntryUserRank : DomainIdEntity
{
    public ForumEntryUserRank() { }

    public ForumEntryUserRank(int forumEntryId,
                              int userId)
    {
        ForumEntryId = forumEntryId;
        UserId = userId;
    }

    public int ForumEntryId { get; private set; }

    public virtual User User { get; private set; }

    public int UserId { get; private set; }
}
