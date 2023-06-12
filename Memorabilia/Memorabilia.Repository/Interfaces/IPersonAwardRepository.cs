namespace Memorabilia.Repository.Interfaces;

public interface IPersonAwardRepository
{
    Task<IEnumerable<Entity.PersonAward>> GetAll(int awardTypeId);
}
