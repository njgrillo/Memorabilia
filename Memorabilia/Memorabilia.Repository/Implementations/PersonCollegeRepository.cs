namespace Memorabilia.Repository.Implementations;

public class PersonCollegeRepository(DomainContext context, IMemoryCache memoryCache)
    : DomainRepository<PersonCollege>(context, memoryCache), IPersonCollegeRepository
{
    private IQueryable<PersonCollege> Colleges 
        => Items.Include(record => record.Person);

    public async Task<IEnumerable<PersonCollege>> GetAll(int? collegeId = null, 
                                                                int? sportId = null)
        => (await Colleges.Where(college => (collegeId == null || college.CollegeId == collegeId)
                                         && (sportId == null || college.Person.Sports.Single(sport => sport.IsPrimary).SportId == sportId))
                          .AsNoTracking()
                          .ToListAsync())
                    .OrderByDescending(college => college.Person.DisplayName);
}
