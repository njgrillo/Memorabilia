namespace Memorabilia.Application.Features.SiteMemorabilia;

public record GetSiteMemorabiliaGalleryItems(PageInfo PageInfo,
                                             MemorabiliaSearchCriteria MemorabiliaSearchCriteria = null)
    : IQuery<SiteMemorabiliaGalleryItemsModel>
{
    public class Handler : QueryHandler<GetSiteMemorabiliaGalleryItems, SiteMemorabiliaGalleryItemsModel>
    {
        private readonly IApplicationStateService _applicationStateService;
        private readonly ISiteMemorabiliaRepository _memorabiliaRepository;

        public Handler(ISiteMemorabiliaRepository memorabiliaRepository,
                       IApplicationStateService applicationStateService)
        {
            _memorabiliaRepository = memorabiliaRepository;
            _applicationStateService = applicationStateService;
        }

        protected override async Task<SiteMemorabiliaGalleryItemsModel> Handle(GetSiteMemorabiliaGalleryItems query)
        {
            int? userId = query.MemorabiliaSearchCriteria.IncludeMyMemorablia
                ? null
                : _applicationStateService.CurrentUser?.Id ?? 0;

            PagedResult<Entity.Memorabilia> result
                = await _memorabiliaRepository.GetAll(query.PageInfo,
                                                      query.MemorabiliaSearchCriteria,
                                                      userId);

            return new SiteMemorabiliaGalleryItemsModel(result.Data, result.PageInfo);
        }
    }
}
