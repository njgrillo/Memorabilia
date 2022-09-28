using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Interfaces
{
    public interface IPriorityTypeRepository
    {
        Task Add(PriorityType priorityType, CancellationToken cancellationToken = default);

        Task Delete(PriorityType priorityType, CancellationToken cancellationToken = default);

        Task<PriorityType> Get(int id);

        Task<IEnumerable<PriorityType>> GetAll();

        Task Update(PriorityType priorityType, CancellationToken cancellationToken = default);
    }
}
