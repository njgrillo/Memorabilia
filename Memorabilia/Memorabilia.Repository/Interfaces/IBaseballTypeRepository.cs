using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Interfaces
{
    public interface IBaseballTypeRepository
    {
        Task Add(BaseballType baseballType, CancellationToken cancellationToken = default);

        Task Delete(BaseballType baseballType, CancellationToken cancellationToken = default);

        Task<BaseballType> Get(int id);

        Task<IEnumerable<BaseballType>> GetAll();

        Task Update(BaseballType baseballType, CancellationToken cancellationToken = default);
    }
}
