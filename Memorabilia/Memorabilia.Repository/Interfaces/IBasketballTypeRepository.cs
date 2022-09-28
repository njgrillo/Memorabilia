using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Interfaces
{
    public interface IBasketballTypeRepository
    {
        Task Add(BasketballType basketballType, CancellationToken cancellationToken = default);

        Task Delete(BasketballType basketballType, CancellationToken cancellationToken = default);

        Task<BasketballType> Get(int id);

        Task<IEnumerable<BasketballType>> GetAll();

        Task Update(BasketballType basketballType, CancellationToken cancellationToken = default);
    }
}
