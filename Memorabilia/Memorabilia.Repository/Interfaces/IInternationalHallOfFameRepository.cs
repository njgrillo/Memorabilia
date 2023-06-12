namespace Memorabilia.Repository.Interfaces;

public interface IInternationalHallOfFameRepository
{
    Task<IEnumerable<Entity.InternationalHallOfFame>> GetAll(int? internationalHallOfFameTypeId = null, 
                                                             int? sportLeagueLevelId = null);
}
