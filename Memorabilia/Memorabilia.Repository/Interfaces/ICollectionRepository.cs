namespace Memorabilia.Repository.Interfaces;

public interface ICollectionRepository 
    : IDomainRepository<Collection>
{
    Task<Collection[]> GetAll(int userId);
}
