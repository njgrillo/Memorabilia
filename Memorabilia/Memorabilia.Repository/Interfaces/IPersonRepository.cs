namespace Memorabilia.Repository.Interfaces;

public interface IPersonRepository : IDomainRepository<Person>
{
    Task<IEnumerable<Person>> GetAll(
        int? sportId = null, 
        int? sportLeagueLevelId = null,
        int? userId = null
        );

    Task<Person[]> GetAll(Dictionary<string, object> parameters, int userId);

    Task<Person[]> GetAll(int teamId, int year, int userId);

    Task<Person[]> GetAll(int[] ids);

    Task<Person[]> GetAllHallOfFamers(int sportLeagueLevelId, int? year);

    Task<PagedResult<Person>> GetAllNicknames(
        PageInfo pageInfo, 
        int? sportId = null, 
        string filter = null
        );

    Task<Person[]> GetMostRecent();
}
