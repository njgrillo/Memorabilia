namespace Memorabilia.Repository.Implementations;

public class CollegeRepository(DomainContext context, IMemoryCache memory)
    : DomainRepository<College>(context, memory), ICollegeRepository
{
    public async Task<PagedResult<College>> GetAll(PageInfo pageInfo, string filter = null)
    {
        filter = $"%{filter}%";

        var query =
                from college in Context.College
                where filter.IsNullOrEmpty()
                    || EF.Functions.Like(college.Name, filter)
                    || EF.Functions.Like(college.Abbreviation, filter)
                orderby college.Name
                select college;

        return await query.ToPagedResult(pageInfo);
    }
}
