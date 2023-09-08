namespace Memorabilia.Application.Features.SiteMemorabilia;

public record GetUserSiteMemorabiliaItems(int UserId,
                                          PageInfo PageInfo,
                                          MemorabiliaSearchCriteria MemorabiliaSearchCriteria = null)
    : IQuery<SiteMemorabiliasModel>
{
    public class Handler : QueryHandler<GetUserSiteMemorabiliaItems, SiteMemorabiliasModel>
    {
        private readonly IApplicationStateService _applicationStateService;
        private readonly ISiteMemorabiliaRepository _memorabiliaRepository;

        public Handler(ISiteMemorabiliaRepository memorabiliaRepository,
                       IApplicationStateService applicationStateService)
        {
            _memorabiliaRepository = memorabiliaRepository;
            _applicationStateService = applicationStateService;
        }

        protected override async Task<SiteMemorabiliasModel> Handle(GetUserSiteMemorabiliaItems query)
        {
            PagedResult<Entity.Memorabilia> result
                = await _memorabiliaRepository.GetAllByUser(query.UserId, 
                                                            query.PageInfo,
                                                            query.MemorabiliaSearchCriteria);

            return new SiteMemorabiliasModel(result.Data, result.PageInfo);
        }
    }
}
