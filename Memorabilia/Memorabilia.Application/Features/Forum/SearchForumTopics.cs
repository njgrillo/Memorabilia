namespace Memorabilia.Application.Features.Forum;

public record SearchForumTopics(PageInfo PageInfo, string SearchText)
    : IQuery<ForumTopicsModel>
{
    public class Handler : QueryHandler<SearchForumTopics, ForumTopicsModel>
    {
        private readonly IForumTopicRepository _forumTopicRepository;

        public Handler(IForumTopicRepository forumTopicRepository)
        {
            _forumTopicRepository = forumTopicRepository;
        }

        protected override async Task<ForumTopicsModel> Handle(SearchForumTopics query)
        {
            PagedResult<Entity.ForumTopic> result
                = await _forumTopicRepository.Search(query.PageInfo, query.SearchText);

            return new ForumTopicsModel(result.Data, result.PageInfo);
        }
    }
}
