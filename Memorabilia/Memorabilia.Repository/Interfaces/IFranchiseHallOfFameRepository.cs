namespace Memorabilia.Repository.Interfaces;

public interface IFranchiseHallOfFameRepository
{
    Task<IEnumerable<Entity.FranchiseHallOfFame>> GetAll(int franchiseId);
}
