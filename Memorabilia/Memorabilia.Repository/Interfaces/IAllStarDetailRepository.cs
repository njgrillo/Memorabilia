namespace Memorabilia.Repository.Interfaces;

public interface IAllStarDetailRepository
    : IDomainRepository<Entity.AllStarDetail>
{
    Task<Entity.AllStarDetail[]> GetAll(int sportLeagueLevelId);
}
