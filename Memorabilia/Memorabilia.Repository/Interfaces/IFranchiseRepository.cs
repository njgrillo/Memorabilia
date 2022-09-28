using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Interfaces
{
    public interface IFranchiseRepository
    {
        Task Add(Franchise franchise, CancellationToken cancellationToken = default);

        Task Delete(Franchise franchise, CancellationToken cancellationToken = default);

        Task<Franchise> Get(int id);

        Task<IEnumerable<Franchise>> GetAll();

        Task Update(Franchise franchise, CancellationToken cancellationToken = default);
    }
}
