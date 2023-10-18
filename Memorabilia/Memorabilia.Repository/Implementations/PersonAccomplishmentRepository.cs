namespace Memorabilia.Repository.Implementations;

public class PersonAccomplishmentRepository 
    : DomainRepository<PersonAccomplishment>, IPersonAccomplishmentRepository
{
    public PersonAccomplishmentRepository(DomainContext context, IMemoryCache memoryCache) 
        : base(context, memoryCache) { }

    private IQueryable<PersonAccomplishment> PersonAccomplishment 
        => Items.Include(personAccomplishment => personAccomplishment.Person);

    public async Task<IEnumerable<PersonAccomplishment>> GetAll(int accomplishmentTypeId)
    {
        PersonAccomplishment[] accomplishments 
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
