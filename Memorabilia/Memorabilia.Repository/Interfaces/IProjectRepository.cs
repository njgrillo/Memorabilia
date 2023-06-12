namespace Memorabilia.Repository.Interfaces;

public interface IProjectRepository : IDomainRepository<Entity.Project>
{
    Task<Entity.Project[]> GetAll(int userId);
}
