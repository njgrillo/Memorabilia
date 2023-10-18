namespace Memorabilia.Repository.Interfaces;

public interface IForumTopicRepository
    : IDomainRepository<ForumTopic>
{
    Task<PagedResult<ForumTopic>> GetAll(PageInfo pageInfo, int forumCategoryId, int? sportId);

    Task<ForumTopic[]> GetAllBookmarked(int userId);

    Task<ForumTopic[]> GetAllTrending();

    Task<PagedResult<ForumTopic>> Search(PageInfo pageInfo, string searchText);
}
