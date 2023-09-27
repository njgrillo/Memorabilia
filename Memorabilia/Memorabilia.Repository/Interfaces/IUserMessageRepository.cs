namespace Memorabilia.Repository.Interfaces;

public interface IUserMessageRepository
    : IDomainRepository<Entity.UserMessage>
{
    Task<PagedResult<Entity.UserMessage>> GetAllReceived(PageInfo pageInfo, int userId, int? userMessageStatusId = null);

    Task<PagedResult<Entity.UserMessage>> GetAllSent(PageInfo pageInfo, int userId, int? userMessageStatusId = null);

    Task<PagedResult<Entity.UserMessage>> SearchReceived(PageInfo pageInfo, string searchText, int userId);

    Task<PagedResult<Entity.UserMessage>> SearchSent(PageInfo pageInfo, string searchText, int userId);
}
