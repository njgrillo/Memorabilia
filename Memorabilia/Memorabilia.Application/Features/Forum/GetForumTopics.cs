namespace Memorabilia.Application.Features.Forum;

public record GetForumTopics(PageInfo PageInfo, int ForumCategoryId, int? SportId = null)
    : IQuery<ForumTopicsModel>
{
    public class Handler(IForumTopicRepository forumTopicRepository) 
        : QueryHandler<GetForumTopics, ForumTopicsModel>
    {
        protected override async Task<ForumTopicsModel> Handle(GetForumTopics query)
        {
            PagedResult<Entity.ForumTopic> result
                = await forumTopicRepository.GetAll(query.PageInfo, query.ForumCategoryId, query.SportId);

            return new ForumTopicsModel(result.Data, result.PageInfo);
        }
    }
}
