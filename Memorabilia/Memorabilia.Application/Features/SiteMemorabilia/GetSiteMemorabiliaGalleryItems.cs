namespace Memorabilia.Application.Features.SiteMemorabilia;

public record GetSiteMemorabiliaGalleryItems(PageInfo PageInfo,
                                             MemorabiliaSearchCriteria MemorabiliaSearchCriteria = null)
    : IQuery<SiteMemorabiliaGalleryItemsModel>
{
    public class Handler(ISiteMemorabiliaRepository memorabiliaRepository,
                         IApplicationStateService applicationStateService) 
        : QueryHandler<GetSiteMemorabiliaGalleryItems, SiteMemorabiliaGalleryItemsModel>
    {
        protected override async Task<SiteMemorabiliaGalleryItemsModel> Handle(GetSiteMemorabiliaGalleryItems query)
        {
            int? userId = query.MemorabiliaSearchCriteria.IncludeMyMemorablia
                ? null
                : applicationStateService.CurrentUser?.Id ?? 0;

            PagedResult<Entity.Memorabilia> result
                = await memorabiliaRepository.GetAll(query.PageInfo,
                                                     query.MemorabiliaSearchCriteria,
                                                     userId);

            return new SiteMemorabiliaGalleryItemsModel(result.Data, result.PageInfo);
        }
    }
}
