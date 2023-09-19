namespace Memorabilia.Repository.Interfaces;

public interface IForumTopicRepository
    : IDomainRepository<Entity.ForumTopic>
{
    Task<PagedResult<Entity.ForumTopic>> GetAll(PageInfo pageInfo, int forumCategoryId, int? sportId);

    Task<Entity.ForumTopic[]> GetAllBookmarked(int userId);

    Task<Entity.ForumTopic[]> GetAllTrending();

    Task<PagedResult<Entity.ForumTopic>> Search(PageInfo pageInfo, string searchText);
}
