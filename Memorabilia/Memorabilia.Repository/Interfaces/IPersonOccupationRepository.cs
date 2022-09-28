using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Interfaces
{
    public interface IPersonOccupationRepository
    {
        Task Add(PersonOccupation personOccupation, CancellationToken cancellationToken = default);

        Task Delete(PersonOccupation personOccupation, CancellationToken cancellationToken = default);

        Task<PersonOccupation> Get(int id);

        Task<IEnumerable<PersonOccupation>> GetAll(int? personId = null);

        Task Update(PersonOccupation personOccupation, CancellationToken cancellationToken = default);
    }
}
