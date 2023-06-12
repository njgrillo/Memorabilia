namespace Memorabilia.Repository.Interfaces;

public interface ICollectionRepository 
    : IDomainRepository<Entity.Collection>
{
    Task<Entity.Collection[]> GetAll(int userId);
}
