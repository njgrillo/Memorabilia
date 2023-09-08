namespace Memorabilia.Application.Features.SiteMemorabilia;

public record GetSiteMemorabiliaItems(PageInfo PageInfo,
                                      MemorabiliaSearchCriteria MemorabiliaSearchCriteria = null)
    : IQuery<SiteMemorabiliasModel>
{
    public class Handler : QueryHandler<GetSiteMemorabiliaItems, SiteMemorabiliasModel>
    {
        private readonly IApplicationStateService _applicationStateService;
        private readonly ISiteMemorabiliaRepository _memorabiliaRepository;

        public Handler(ISiteMemorabiliaRepository memorabiliaRepository,
                       IApplicationStateService applicationStateService)
        {
            _memorabiliaRepository = memorabiliaRepository;
            _applicationStateService = applicationStateService;
        }

        protected override async Task<SiteMemorabiliasModel> Handle(GetSiteMemorabiliaItems query)
        {
            int? userId = query.MemorabiliaSearchCriteria.IncludeMyMemorablia
                ? null
                : _applicationStateService.CurrentUser.Id;

            PagedResult<Entity.Memorabilia> result
                = await _memorabiliaRepository.GetAll(query.PageInfo,
                                                      query.MemorabiliaSearchCriteria,
                                                      userId);

            return new SiteMemorabiliasModel(result.Data, result.PageInfo);
        }
    }
}
