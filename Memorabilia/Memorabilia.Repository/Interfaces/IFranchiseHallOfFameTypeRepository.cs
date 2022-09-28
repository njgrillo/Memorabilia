using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Interfaces
{
    public interface IFranchiseHallOfFameTypeRepository
    {
        Task Add(FranchiseHallOfFameType franchiseHallOfFameType, CancellationToken cancellationToken = default);

        Task Delete(FranchiseHallOfFameType franchiseHallOfFameType, CancellationToken cancellationToken = default);

        Task<FranchiseHallOfFameType> Get(int id);

        Task<IEnumerable<FranchiseHallOfFameType>> GetAll();

        Task Update(FranchiseHallOfFameType franchiseHallOfFameType, CancellationToken cancellationToken = default);
    }
}
