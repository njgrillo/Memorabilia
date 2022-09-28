using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Interfaces
{
    public interface ISportServiceRepository
    {
        Task Add(SportService sportService, CancellationToken cancellationToken = default);

        Task Delete(SportService sportService, CancellationToken cancellationToken = default);

        Task<SportService> Get(int personId);

        Task<IEnumerable<SportService>> GetAll();

        Task Update(SportService sportService, CancellationToken cancellationToken = default);
    }
}
