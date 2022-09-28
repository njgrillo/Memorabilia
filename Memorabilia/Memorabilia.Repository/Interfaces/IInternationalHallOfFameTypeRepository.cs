using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Interfaces
{
    public interface IInternationalHallOfFameTypeRepository
    {
        Task Add(InternationalHallOfFameType internationalHallOfFameType, CancellationToken cancellationToken = default);

        Task Delete(InternationalHallOfFameType internationalHallOfFameType, CancellationToken cancellationToken = default);

        Task<InternationalHallOfFameType> Get(int id);

        Task<IEnumerable<InternationalHallOfFameType>> GetAll();

        Task Update(InternationalHallOfFameType internationalHallOfFameType, CancellationToken cancellationToken = default);
    }
}
