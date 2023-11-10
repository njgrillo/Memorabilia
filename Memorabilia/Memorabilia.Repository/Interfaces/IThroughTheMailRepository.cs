namespace Memorabilia.Repository.Interfaces;

public interface IThroughTheMailRepository 
    : IDomainRepository<ThroughTheMail>
{
    Task<Address[]> GetAddresses(int personId);

    Task<ThroughTheMail[]> GetAll(int userId, int[] throughTheMailIds = null);
}
