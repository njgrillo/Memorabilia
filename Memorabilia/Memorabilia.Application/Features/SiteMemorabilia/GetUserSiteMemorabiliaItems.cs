namespace Memorabilia.Application.Features.SiteMemorabilia;

public record GetUserSiteMemorabiliaItems(int UserId,
                                          PageInfo PageInfo,
                                          MemorabiliaSearchCriteria MemorabiliaSearchCriteria = null)
    : IQuery<SiteMemorabiliasModel>
{
    public class Handler(ISiteMemorabiliaRepository memorabiliaRepository) 
        : QueryHandler<GetUserSiteMemorabiliaItems, SiteMemorabiliasModel>
    {
        protected override async Task<SiteMemorabiliasModel> Handle(GetUserSiteMemorabiliaItems query)
        {
            PagedResult<Entity.Memorabilia> result
                = await memorabiliaRepository.GetAllByUser(query.UserId, 
                                                           query.PageInfo,
                                                           query.MemorabiliaSearchCriteria);

            return new SiteMemorabiliasModel(result.Data, result.PageInfo);
        }
    }
}
