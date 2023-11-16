namespace Memorabilia.Repository.Cache;

public class PersonCollegeCacheRepository(DomainContext context,
                                          PersonCollegeRepository personCollegeRepository,
                                          IMemoryCache memoryCache)
    : DomainCacheRepository<PersonCollege>(context, memoryCache), IPersonCollegeRepository
{
    public Task<IEnumerable<PersonCollege>> GetAll(int? collegeId = null, 
                                                   int? sportLeagueLevelId = null)
        => GetAll($"PersonCollege_GetAll_{collegeId}_{sportLeagueLevelId}", 
                  entry =>
                  {
                      entry.SetAbsoluteExpiration(TimeSpan.FromDays(1));
                      return personCollegeRepository.GetAll(collegeId, sportLeagueLevelId);
                  });
}
