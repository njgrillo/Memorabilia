namespace Memorabilia.Repository.Interfaces;

public interface IInternationalHallOfFameRepository
{
    Task<IEnumerable<InternationalHallOfFame>> GetAll(int? internationalHallOfFameTypeId = null, 
                                                             int? sportLeagueLevelId = null);
}
