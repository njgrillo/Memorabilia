using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Implementations;

public class PersonCollegeRepository : DomainRepository<PersonCollege>, IPersonCollegeRepository
{
    public PersonCollegeRepository(DomainContext context) : base(context) { }

    private IQueryable<PersonCollege> Colleges => Items.Include(record => record.Person);

    public async Task<IEnumerable<PersonCollege>> GetAll(int? collegeId = null, int? sportLeagueLevelId = null)
    {
        return (await Colleges.Where(college => (collegeId == null || college.CollegeId == collegeId)
                                             && (sportLeagueLevelId == null || college.Person.Teams.Select(team => team.Team.Franchise.SportLeagueLevelId).Contains(sportLeagueLevelId.Value)))
                              .AsNoTracking()
                              .ToListAsync())
                .OrderByDescending(college => college.Person.DisplayName);
    }
}
