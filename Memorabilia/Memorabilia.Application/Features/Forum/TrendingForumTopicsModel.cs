namespace Memorabilia.Application.Features.Forum;

public class TrendingForumTopicsModel
{
    public TrendingForumTopicsModel() { }

    public TrendingForumTopicsModel(Entity.ForumTopic[] trendingTopics)
    {
        TrendingTopics = trendingTopics.Select(topic => new ForumTopicModel(topic))
                                       .ToArray();
    }

    public ForumTopicModel[] TrendingTopics { get; set; }
        = Array.Empty<ForumTopicModel>();
}
