namespace Memorabilia.Repository.Interfaces;

public interface IThroughTheMailRepository 
    : IDomainRepository<ThroughTheMail>
{
    Task<Address[]> GetAddresses(int personId);

    Task<ThroughTheMail[]> GetAll(int userId, int[] throughTheMailIds = null);

    Task<PagedResult<ThroughTheMail>> GetAllReceived(PageInfo pageInfo, int userId);

    Task<int> GetAllReceivedCount(int userId);

    Task<PagedResult<ThroughTheMail>> GetAllSent(PageInfo pageInfo, int userId);

    Task<int> GetAllSentCount(int userId);
}
