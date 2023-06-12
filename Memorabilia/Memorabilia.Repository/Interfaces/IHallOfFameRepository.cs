namespace Memorabilia.Repository.Interfaces;

public interface IHallOfFameRepository : IDomainRepository<Entity.HallOfFame>
{
    Task<IEnumerable<Entity.HallOfFame>> GetAll(int? sportLeagueLevelId = null, int? inductionYear = null);
}
