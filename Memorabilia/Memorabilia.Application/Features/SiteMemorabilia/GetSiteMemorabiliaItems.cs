using Memorabilia.Application.Services.Interfaces;

namespace Memorabilia.Application.Features.SiteMemorabilia;

public record GetSiteMemorabiliaItems(PageInfo PageInfo,
                                      MemorabiliaSearchCriteria MemorabiliaSearchCriteria = null)
    : IQuery<SiteMemorabiliasModel>
{
    public class Handler(ISiteMemorabiliaRepository memorabiliaRepository,
                         IApplicationStateService applicationStateService) 
        : QueryHandler<GetSiteMemorabiliaItems, SiteMemorabiliasModel>
    {
        protected override async Task<SiteMemorabiliasModel> Handle(GetSiteMemorabiliaItems query)
        {
            int? userId = query.MemorabiliaSearchCriteria.IncludeMyMemorablia
                ? null
                : applicationStateService.CurrentUser?.Id ?? 0;

            PagedResult<Entity.Memorabilia> result
                = await memorabiliaRepository.GetAll(query.PageInfo,
                                                     query.MemorabiliaSearchCriteria,
                                                     userId);

            return new SiteMemorabiliasModel(result.Data, result.PageInfo);
        }
    }
}
