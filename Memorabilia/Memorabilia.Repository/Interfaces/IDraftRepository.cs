namespace Memorabilia.Repository.Interfaces;

public interface IDraftRepository
{
    Task<IEnumerable<Draft>> GetAll(int franchiseId);
}
