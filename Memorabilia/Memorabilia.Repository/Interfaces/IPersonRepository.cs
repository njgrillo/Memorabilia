using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Interfaces;

public interface IPersonRepository : IDomainRepository<Person>
{
    Task<IEnumerable<Person>> GetAll(int? sportId = null, int? sportLeagueLevelId = null);

    Task<Person[]> GetAll(Dictionary<string, object> parameters);

    Task<Person[]> GetAll(int teamId, int year);

    Task<Person[]> GetAllHallOfFamers(int sportLeagueLevelId, int? year);

    Task<Person[]> GetMostRecent();
}
