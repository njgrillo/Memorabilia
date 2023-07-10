namespace Memorabilia.Repository.Interfaces;

public interface IPersonRepository : IDomainRepository<Entity.Person>
{
    Task<Entity.Person> Get(string displayName = null,
                            string profileName = null,
                            string legalName = null);

    Task<IEnumerable<Entity.Person>> GetAll(int? sportId = null, 
                                            int? sportLeagueLevelId = null);

    Task<Entity.Person[]> GetAll(Dictionary<string, object> parameters);

    Task<Entity.Person[]> GetAll(int teamId, int year);

    Task<Entity.Person[]> GetAllHallOfFamers(int sportLeagueLevelId, int? year);

    Task<Entity.Person[]> GetMostRecent();
}
