namespace Memorabilia.Repository.Interfaces;

public interface IDisplayCaseRepository : IDomainRepository<DisplayCase>
{
    Task<DisplayCase[]> GetAll(int userId);

    Task<DisplayCase[]> GetAllPublic();
}
