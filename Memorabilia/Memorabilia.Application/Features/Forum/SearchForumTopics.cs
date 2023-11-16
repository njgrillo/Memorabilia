namespace Memorabilia.Application.Features.Forum;

public record SearchForumTopics(PageInfo PageInfo, string SearchText)
    : IQuery<ForumTopicsModel>
{
    public class Handler(IForumTopicRepository forumTopicRepository) 
        : QueryHandler<SearchForumTopics, ForumTopicsModel>
    {
        protected override async Task<ForumTopicsModel> Handle(SearchForumTopics query)
        {
            PagedResult<Entity.ForumTopic> result
                = await forumTopicRepository.Search(query.PageInfo, query.SearchText);

            return new ForumTopicsModel(result.Data, result.PageInfo);
        }
    }
}
