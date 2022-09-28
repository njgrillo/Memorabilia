using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Interfaces
{
    public interface ICommissionerRepository
    {
        Task Add(Commissioner commissioner, CancellationToken cancellationToken = default);

        Task Delete(Commissioner commissioner, CancellationToken cancellationToken = default);

        Task<Commissioner> Get(int id);

        Task<IEnumerable<Commissioner>> GetAll(int? sportLeagueLevelId = null);

        Task Update(Commissioner commissioner, CancellationToken cancellationToken = default);
    }
}
