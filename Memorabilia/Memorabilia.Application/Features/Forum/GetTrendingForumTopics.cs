namespace Memorabilia.Application.Features.Forum;

public record GetTrendingForumTopics() : IQuery<Entity.ForumTopic[]>
{
    public class Handler(IForumTopicRepository forumTopicRepository) 
        : QueryHandler<GetTrendingForumTopics, Entity.ForumTopic[]>
    {
        protected override async Task<Entity.ForumTopic[]> Handle(GetTrendingForumTopics query)
            => (await forumTopicRepository.GetAllTrending())
                    .OrderByDescending(offer => offer.CreatedDate)
                    .ToArray();
    }
}
