namespace Memorabilia.Repository.Interfaces;

public interface IAllStarDetailRepository
    : IDomainRepository<AllStarDetail>
{
    Task<AllStarDetail[]> GetAll(int sportLeagueLevelId);
}
