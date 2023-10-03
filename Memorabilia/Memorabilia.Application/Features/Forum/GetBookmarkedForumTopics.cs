namespace Memorabilia.Application.Features.Forum;

[AuthorizeByPermission(Enum.Permission.Forum)]
public record GetBookmarkedForumTopics(int UserId)
     : IQuery<Entity.ForumTopic[]>
{
    public class Handler : QueryHandler<GetBookmarkedForumTopics, Entity.ForumTopic[]>
    {
        private readonly IForumTopicRepository _forumTopicRepository;

        public Handler(IForumTopicRepository forumTopicRepository)
        {
            _forumTopicRepository = forumTopicRepository;
        }

        protected override async Task<Entity.ForumTopic[]> Handle(GetBookmarkedForumTopics query)
            => await _forumTopicRepository.GetAllBookmarked(query.UserId);
    }
}
