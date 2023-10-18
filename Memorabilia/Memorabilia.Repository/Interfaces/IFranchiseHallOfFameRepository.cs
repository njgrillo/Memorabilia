namespace Memorabilia.Repository.Interfaces;

public interface IFranchiseHallOfFameRepository
{
    Task<IEnumerable<FranchiseHallOfFame>> GetAll(int franchiseId);
}
