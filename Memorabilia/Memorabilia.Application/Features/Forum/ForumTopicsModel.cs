namespace Memorabilia.Application.Features.Forum;

public class ForumTopicsModel : Model
{
	public ForumTopicsModel() { }

    public ForumTopicsModel(Entity.ForumTopic[] forumTopics)
    {
        ForumTopics = forumTopics.Select(topic => new ForumTopicModel(topic))
                                 .ToList();
    }

    public ForumTopicsModel(Entity.ForumTopic[] forumTopics, PageInfoResult pageInfo)
	{
        ForumTopics = forumTopics.Select(topic => new ForumTopicModel(topic))
                                 .ToList();

        PageInfo = pageInfo;
    }

    public List<ForumTopicModel> ForumTopics { get; set; }
        = new();
}
