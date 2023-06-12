namespace Memorabilia.Repository.Cache;

public class PersonCollegeCacheRepository 
    : DomainCacheRepository<Entity.PersonCollege>, IPersonCollegeRepository
{
    private readonly PersonCollegeRepository _personCollegeRepository;

    public PersonCollegeCacheRepository(DomainContext context, 
                                        PersonCollegeRepository personCollegeRepository, 
                                        IMemoryCache memoryCache)
        : base(context, memoryCache)
    {
        _personCollegeRepository = personCollegeRepository;
    }

    public Task<IEnumerable<Entity.PersonCollege>> GetAll(int? collegeId = null, 
                                                          int? sportLeagueLevelId = null)
        => GetAll($"PersonCollege_GetAll_{collegeId}_{sportLeagueLevelId}", 
                  entry =>
                  {
                      entry.SetAbsoluteExpiration(TimeSpan.FromDays(1));
                      return _personCollegeRepository.GetAll(collegeId, sportLeagueLevelId);
                  });
}
