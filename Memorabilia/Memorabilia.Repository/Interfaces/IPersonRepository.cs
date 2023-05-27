using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Interfaces;

public interface IPersonRepository : IDomainRepository<Person>
{
    Task<IEnumerable<Person>> GetAll(int? sportId = null, int? sportLeagueLevelId = null);

    Task<Person[]> GetAll(Dictionary<string, object> parameters);

    Task<Person[]> GetMostRecent();
}
