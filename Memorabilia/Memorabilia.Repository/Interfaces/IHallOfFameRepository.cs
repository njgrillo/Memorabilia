namespace Memorabilia.Repository.Interfaces;

public interface IHallOfFameRepository : IDomainRepository<HallOfFame>
{
    Task<IEnumerable<HallOfFame>> GetAll(int? sportLeagueLevelId = null, int? inductionYear = null);
}
