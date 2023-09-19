namespace Memorabilia.Application.Features.Forum;

public record GetForumTopics(PageInfo PageInfo, int ForumCategoryId, int? SportId = null)
    : IQuery<ForumTopicsModel>
{
    public class Handler : QueryHandler<GetForumTopics, ForumTopicsModel>
    {
        private readonly IForumTopicRepository _forumTopicRepository;

        public Handler(IForumTopicRepository forumTopicRepository)
        {
            _forumTopicRepository = forumTopicRepository;
        }

        protected override async Task<ForumTopicsModel> Handle(GetForumTopics query)
        {
            PagedResult<Entity.ForumTopic> result
                = await _forumTopicRepository.GetAll(query.PageInfo, query.ForumCategoryId, query.SportId);

            return new ForumTopicsModel(result.Data, result.PageInfo);
        }
    }
}
