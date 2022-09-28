using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Interfaces
{
    public interface IBrandRepository
    {
        Task Add(Brand brand, CancellationToken cancellationToken = default);

        Task Delete(Brand brand, CancellationToken cancellationToken = default);

        Task<Brand> Get(int id);

        Task<IEnumerable<Brand>> GetAll();

        Task Update(Brand brand, CancellationToken cancellationToken = default);
    }
}
