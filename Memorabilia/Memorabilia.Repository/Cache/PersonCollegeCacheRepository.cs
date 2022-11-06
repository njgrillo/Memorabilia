using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Cache;

public class PersonCollegeCacheRepository : DomainCacheRepository<PersonCollege>, IPersonCollegeRepository
{
    private readonly PersonCollegeRepository _personCollegeRepository;

    public PersonCollegeCacheRepository(DomainContext context, PersonCollegeRepository personCollegeRepository, IMemoryCache memoryCache)
        : base(context, memoryCache)
    {
        _personCollegeRepository = personCollegeRepository;
    }

    public Task<IEnumerable<PersonCollege>> GetAll(int? collegeId = null, int? sportLeagueLevelId = null)
    {
        return GetAll($"PersonCollege_GetAll_{collegeId}_{sportLeagueLevelId}", entry =>
        {
            entry.SetAbsoluteExpiration(TimeSpan.FromDays(1));
            return _personCollegeRepository.GetAll(collegeId, sportLeagueLevelId);
        });
    }
}
