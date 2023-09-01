namespace Memorabilia.Application.Features.Transaction;

public record GetPurchaseMemorabiliaItemsPaged(PageInfo PageInfo,
    MemorabiliaSearchCriteria Filter = null)
    : IQuery<PurchaseMemorabiliasModel>
{
    public class Handler : QueryHandler<GetPurchaseMemorabiliaItemsPaged, PurchaseMemorabiliasModel>
    {
        private readonly IApplicationStateService _applicationStateService;
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository,
                       IApplicationStateService applicationStateService)
        {
            _memorabiliaRepository = memorabiliaRepository;
            _applicationStateService = applicationStateService;
        }

        protected override async Task<PurchaseMemorabiliasModel> Handle(GetPurchaseMemorabiliaItemsPaged query)
        {
            PagedResult<Entity.Memorabilia> result
                = await _memorabiliaRepository.GetAllPurchased(_applicationStateService.CurrentUser.Id,
                                                                query.PageInfo,
                                                                query.Filter ?? new MemorabiliaSearchCriteria());

            return new PurchaseMemorabiliasModel(result.Data, result.PageInfo);
        }
    }
}
