namespace Memorabilia.Application.Features.Forum;

public record GetForumTopic(int ForumTopicId)
    : IQuery<Entity.ForumTopic>
{
    public class Handler : QueryHandler<GetForumTopic, Entity.ForumTopic>
    {
        private readonly IForumTopicRepository _forumTopicRepository;

        public Handler(IForumTopicRepository forumTopicRepository)
        {
            _forumTopicRepository = forumTopicRepository;
        }

        protected override async Task<Entity.ForumTopic> Handle(GetForumTopic query)
            => await _forumTopicRepository.Get(query.ForumTopicId);
    }
}
