namespace Memorabilia.Repository.Interfaces;

public interface IThroughTheMailRepository 
    : IDomainRepository<Entity.ThroughTheMail>
{
    Task<Entity.ThroughTheMail[]> GetAll(int userId);
}
