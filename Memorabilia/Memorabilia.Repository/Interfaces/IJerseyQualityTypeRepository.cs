using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Interfaces
{
    public interface IJerseyQualityTypeRepository
    {
        Task Add(JerseyQualityType jerseyQualityType, CancellationToken cancellationToken = default);

        Task Delete(JerseyQualityType jerseyQualityType, CancellationToken cancellationToken = default);

        Task<JerseyQualityType> Get(int id);

        Task<IEnumerable<JerseyQualityType>> GetAll();

        Task Update(JerseyQualityType jerseyQualityType, CancellationToken cancellationToken = default);
    }
}
