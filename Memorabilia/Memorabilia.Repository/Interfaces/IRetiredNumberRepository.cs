namespace Memorabilia.Repository.Interfaces;

public interface IRetiredNumberRepository
{
    Task<IEnumerable<RetiredNumber>> GetAll(int franchiseId);
}
