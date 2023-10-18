namespace Memorabilia.Repository.Interfaces;

public interface IThroughTheMailRepository 
    : IDomainRepository<ThroughTheMail>
{
    Task<ThroughTheMail[]> GetAll(int userId, int[] throughTheMailIds = null);
}
