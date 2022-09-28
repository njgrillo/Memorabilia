using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Interfaces
{
    public interface IAccomplishmentTypeRepository
    {
        Task Add(AccomplishmentType accomplishmentType, CancellationToken cancellationToken = default);

        Task Delete(AccomplishmentType accomplishmentType, CancellationToken cancellationToken = default);

        Task<AccomplishmentType> Get(int id);

        Task<IEnumerable<AccomplishmentType>> GetAll();

        Task Update(AccomplishmentType accomplishmentType, CancellationToken cancellationToken = default);
    }
}
