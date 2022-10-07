using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Interfaces;

public interface IProjectRepository : IDomainRepository<Project>
{
    Task<IEnumerable<Project>> GetAll(int userId);
}
