namespace Memorabilia.Repository.Interfaces;

public interface ICommissionerRepository 
    : IDomainRepository<Commissioner>
{
    Task<Commissioner[]> GetAll(int? sportLeagueLevelId = null);
}
