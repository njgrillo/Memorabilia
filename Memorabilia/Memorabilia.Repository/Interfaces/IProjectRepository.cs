using Memorabilia.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository.Interfaces
{
    public interface IProjectRepository
    {
        Task Add(Project project, CancellationToken cancellationToken = default);

        Task Delete(Project project, CancellationToken cancellationToken = default);

        Task<Project> Get(int id);

        Task<IEnumerable<Project>> GetAll(int userId);

        Task Update(Project project, CancellationToken cancellationToken = default);
    }
}
