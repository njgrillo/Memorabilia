namespace Memorabilia.Application.Features.Transaction;

public record GetTradedMemorabiliaTransactionPaged(PageInfo PageInfo,
    MemorabiliaSearchCriteria Filter = null)
    : IQuery<MemorabiliaTransactionsModel>
{
    public class Handler : QueryHandler<GetTradedMemorabiliaTransactionPaged, MemorabiliaTransactionsModel>
    {
        private readonly IApplicationStateService _applicationStateService;
        private readonly IMemorabiliaTransactionRepository _memorabiliaTransactionRepository;

        public Handler(IMemorabiliaTransactionRepository memorabiliaTransactionRepository,
                       IApplicationStateService applicationStateService)
        {
            _memorabiliaTransactionRepository = memorabiliaTransactionRepository;
            _applicationStateService = applicationStateService;
        }

        protected override async Task<MemorabiliaTransactionsModel> Handle(GetTradedMemorabiliaTransactionPaged query)
        {
            PagedResult<Entity.MemorabiliaTransaction> result
                = await _memorabiliaTransactionRepository.GetAllTrades(query.PageInfo,
                                                                       _applicationStateService.CurrentUser.Id,
                                                                       query.Filter ?? new MemorabiliaSearchCriteria());

            return new MemorabiliaTransactionsModel(result.Data, result.PageInfo);
        }
    }
}
