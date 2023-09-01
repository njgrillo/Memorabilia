namespace Memorabilia.Application.Features.Transaction;

public record GetSoldMemorabiliaTransactionPaged(PageInfo PageInfo,
    MemorabiliaSearchCriteria Filter = null)
    : IQuery<MemorabiliaTransactionsModel>
{
    public class Handler : QueryHandler<GetSoldMemorabiliaTransactionPaged, MemorabiliaTransactionsModel>
    {
        private readonly IApplicationStateService _applicationStateService;
        private readonly IMemorabiliaTransactionRepository _memorabiliaTransactionRepository;

        public Handler(IMemorabiliaTransactionRepository memorabiliaTransactionRepository,
                       IApplicationStateService applicationStateService)
        {
            _memorabiliaTransactionRepository = memorabiliaTransactionRepository;
            _applicationStateService = applicationStateService;
        }

        protected override async Task<MemorabiliaTransactionsModel> Handle(GetSoldMemorabiliaTransactionPaged query)
        {
            PagedResult<Entity.MemorabiliaTransaction> result
                = await _memorabiliaTransactionRepository.GetAllSales(query.PageInfo,
                                                                      _applicationStateService.CurrentUser.Id,
                                                                      query.Filter ?? new MemorabiliaSearchCriteria());

            return new MemorabiliaTransactionsModel(result.Data, result.PageInfo);
        }
    }
}
