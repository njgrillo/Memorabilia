namespace Memorabilia.Repository.Implementations;

public class PersonAccomplishmentRepository 
    : DomainRepository<Entity.PersonAccomplishment>, IPersonAccomplishmentRepository
{
    public PersonAccomplishmentRepository(DomainContext context, IMemoryCache memoryCache) 
        : base(context, memoryCache) { }

    private IQueryable<Entity.PersonAccomplishment> PersonAccomplishment 
        => Items.Include(personAccomplishment => personAccomplishment.Person);

    public async Task<IEnumerable<Entity.PersonAccomplishment>> GetAll(int accomplishmentTypeId)
    {
        Entity.PersonAccomplishment[] accomplishments 
            = await PersonAccomplishment.Where(personAccomplishment => personAccomplishment.AccomplishmentTypeId == accomplishmentTypeId)
                                        .AsNoTracking()
                                        .ToArrayAsync();

        bool sortByDate = accomplishments.Any(personAccomplishment => personAccomplishment.Date.HasValue);

        return sortByDate 
            ? accomplishments.OrderByDescending(personAccomplishment => personAccomplishment.Date)
                            .ThenBy(personAccomplishment => personAccomplishment.Person.DisplayName)
            : accomplishments.OrderByDescending(personAccomplishment => personAccomplishment.Year)
                            .ThenBy(personAccomplishment => personAccomplishment.Person.DisplayName);
    }
}
