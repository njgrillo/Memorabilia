using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Interfaces
{
    public interface IConferenceRepository
    {
        Task Add(Conference conference, CancellationToken cancellationToken = default);

        Task Delete(Conference conference, CancellationToken cancellationToken = default);

        Task<Conference> Get(int id);

        Task<IEnumerable<Conference>> GetAll();

        Task Update(Conference conference, CancellationToken cancellationToken = default);
    }
}
