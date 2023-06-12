namespace Memorabilia.Repository.Implementations;

public class PersonCollegeRepository 
    : DomainRepository<Entity.PersonCollege>, IPersonCollegeRepository
{
    public PersonCollegeRepository(DomainContext context, IMemoryCache memoryCache) 
        : base(context, memoryCache) { }

    private IQueryable<Entity.PersonCollege> Colleges 
        => Items.Include(record => record.Person);

    public async Task<IEnumerable<Entity.PersonCollege>> GetAll(int? collegeId = null, 
                                                                int? sportId = null)
        => (await Colleges.Where(college => (collegeId == null || college.CollegeId == collegeId)
                                             && (sportId == null || college.Person.Sports.Single(sport => sport.IsPrimary).SportId == sportId))
                          .AsNoTracking()
                          .ToListAsync())
                    .OrderByDescending(college => college.Person.DisplayName);
}
