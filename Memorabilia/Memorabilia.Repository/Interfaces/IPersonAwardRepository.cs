namespace Memorabilia.Repository.Interfaces;

public interface IPersonAwardRepository
{
    Task<PersonAward[]> GetAll();

    Task<IEnumerable<PersonAward>> GetAll(int awardTypeId);
}
