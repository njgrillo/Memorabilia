namespace Memorabilia.Repository.Interfaces;

public interface IDraftRepository
{
    Task<IEnumerable<Entity.Draft>> GetAll(int franchiseId);
}
