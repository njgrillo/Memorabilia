namespace Memorabilia.Repository.Interfaces;

public interface ICommissionerRepository 
    : IDomainRepository<Entity.Commissioner>
{
    Task<Entity.Commissioner[]> GetAll(int? sportLeagueLevelId = null);
}
