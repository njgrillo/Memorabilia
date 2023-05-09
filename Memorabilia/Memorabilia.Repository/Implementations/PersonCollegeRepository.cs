using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Implementations;

public class PersonCollegeRepository : DomainRepository<PersonCollege>, IPersonCollegeRepository
{
    public PersonCollegeRepository(DomainContext context, IMemoryCache memoryCache) : base(context, memoryCache) { }

    private IQueryable<PersonCollege> Colleges => Items.Include(record => record.Person);

    public async Task<IEnumerable<PersonCollege>> GetAll(int? collegeId = null, int? sportId = null)
    {
        return (await Colleges.Where(college => (collegeId == null || college.CollegeId == collegeId)
                                             && (sportId == null || college.Person.Sports.Single(sport => sport.IsPrimary).SportId == sportId))
                              .AsNoTracking()
                              .ToListAsync())
                .OrderByDescending(college => college.Person.DisplayName);
    }
}
