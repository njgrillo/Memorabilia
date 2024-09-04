namespace Memorabilia.Repository.Interfaces;

public interface IMountRushmoreRepository : IDomainRepository<MountRushmore>
{
    Task<MountRushmore[]> GetAll(int userId);

    Task<MountRushmore[]> GetAllPublic();
}
