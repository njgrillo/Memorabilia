using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Interfaces
{
    public interface IConditionRepository
    {
        Task Add(Condition condition, CancellationToken cancellationToken = default);

        Task Delete(Condition condition, CancellationToken cancellationToken = default);

        Task<Condition> Get(int id);

        Task<IEnumerable<Condition>> GetAll();

        Task Update(Condition condition, CancellationToken cancellationToken = default);
    }
}
