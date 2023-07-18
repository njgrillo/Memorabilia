namespace Memorabilia.Repository.Interfaces;

public interface IPersonAwardRepository
{
    Task<Entity.PersonAward[]> GetAll();

    Task<IEnumerable<Entity.PersonAward>> GetAll(int awardTypeId);
}
