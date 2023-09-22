namespace Memorabilia.Repository.Interfaces;

public interface IUserMessageRepository
    : IDomainRepository<Entity.UserMessage>
{
    Task<PagedResult<Entity.UserMessage>> GetAll(PageInfo pageInfo, int userId, int? userMessageStatusId = null);

    Task<PagedResult<Entity.UserMessage>> Search(PageInfo pageInfo, string searchText, int userId);
}
