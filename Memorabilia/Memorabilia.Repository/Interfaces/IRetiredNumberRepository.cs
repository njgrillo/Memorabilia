namespace Memorabilia.Repository.Interfaces;

public interface IRetiredNumberRepository
{
    Task<IEnumerable<Entity.RetiredNumber>> GetAll(int franchiseId);
}
