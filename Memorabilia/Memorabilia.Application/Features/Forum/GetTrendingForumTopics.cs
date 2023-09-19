namespace Memorabilia.Application.Features.Forum;

public record GetTrendingForumTopics() : IQuery<Entity.ForumTopic[]>
{
    public class Handler : QueryHandler<GetTrendingForumTopics, Entity.ForumTopic[]>
    {
        private readonly IForumTopicRepository _forumTopicRepository;

        public Handler(IForumTopicRepository forumTopicRepository)
        {
            _forumTopicRepository = forumTopicRepository;
        }

        protected override async Task<Entity.ForumTopic[]> Handle(GetTrendingForumTopics query)
            => (await _forumTopicRepository.GetAllTrending())
                    .OrderByDescending(offer => offer.CreatedDate)
                    .ToArray();
    }
}
