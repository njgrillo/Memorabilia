using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Interfaces
{
    public interface IOccupationRepository
    {
        Task Add(Occupation occupation, CancellationToken cancellationToken = default);

        Task Delete(Occupation occupation, CancellationToken cancellationToken = default);

        Task<Occupation> Get(int id);

        Task<IEnumerable<Occupation>> GetAll();

        Task Update(Occupation occupation, CancellationToken cancellationToken = default);
    }
}
