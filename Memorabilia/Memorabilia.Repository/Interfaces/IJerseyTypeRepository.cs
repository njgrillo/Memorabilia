using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Interfaces
{
    public interface IJerseyTypeRepository
    {
        Task Add(JerseyType jerseyType, CancellationToken cancellationToken = default);

        Task Delete(JerseyType jerseyType, CancellationToken cancellationToken = default);

        Task<JerseyType> Get(int id);

        Task<IEnumerable<JerseyType>> GetAll();

        Task Update(JerseyType jerseyType, CancellationToken cancellationToken = default);
    }
}
