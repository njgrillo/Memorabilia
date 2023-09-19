namespace Memorabilia.Application.Features.Forum;

public class ForumTopicModel
{
    private readonly Entity.ForumTopic _forumTopic;

    public ForumTopicModel() { }

    public ForumTopicModel(Entity.ForumTopic forumTopic)
    {
        _forumTopic = forumTopic;
    }

    public Entity.User CreatedByUser
        => _forumTopic.CreatedByUser;

    public int CreatedByUserId
        => _forumTopic.CreatedByUserId;

    public string CreatedByUsername
        => _forumTopic.CreatedByUser.Username;

    public DateTime CreatedDate
        => _forumTopic.CreatedDate;

    public Entity.ForumEntry[] Entries
        => _forumTopic.Entries.ToArray();

    public int EntryCount
        => Entries.Length;   

    public Constant.ForumCategory ForumCategory
        => Constant.ForumCategory.Find(ForumCategoryId);

    public int ForumCategoryId
        => _forumTopic.ForumCategoryId;

    public string ForumCategoryName
        => ForumCategory?.Name;

    public int Id
        => _forumTopic.Id;

    public Entity.ForumEntry LastReply
        => _forumTopic.Entries
                      .OrderByDescending(entry => entry.CreatedDate)
                      .FirstOrDefault();

    public DateTime? LastReplyByDate
        => LastReply?.CreatedDate;

    public string LastReplyByUsername
        => LastReply?.CreatedByUser
                    ?.Username;  

    public DateTime? ModifiedDate
        => _forumTopic.ModifiedDate;

    public Constant.Sport Sport
        => Constant.Sport.Find(SportId ?? 0);

    public int? SportId
        => _forumTopic.SportId;

    public string SportName
        => Sport?.Name;

    public string Subject
        => _forumTopic.Subject;
}
