namespace Memorabilia.Repository.Interfaces;

public interface IProjectRepository : IDomainRepository<Project>
{
    Task<Project[]> GetAll(int userId);
}
