namespace Memorabilia.Application.Features.ForTrade;

[AuthorizeByPermission(Enum.Permission.BuySellTrade)]
public record GetForTradeMemorabiliaItemsPaged(PageInfo PageInfo,
                                               MemorabiliaSearchCriteria MemorabiliaSearchCriteria = null)
    : IQuery<MemorabiliasModel>
{
    public class Handler : QueryHandler<GetForTradeMemorabiliaItemsPaged, MemorabiliasModel>
    {
        private readonly IApplicationStateService _applicationStateService;
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IApplicationStateService applicationStateService,
            IMemorabiliaItemRepository memorabiliaRepository)
        {
            _applicationStateService = applicationStateService;
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<MemorabiliasModel> Handle(GetForTradeMemorabiliaItemsPaged query)
        {
            var result = await _memorabiliaRepository.GetAllForTrade(_applicationStateService.CurrentUser.Id, 
                                                                     query.PageInfo, 
                                                                     query.MemorabiliaSearchCriteria);

            return new MemorabiliasModel(result.Data, result.PageInfo);
        }
    }
}
