namespace Memorabilia.Application.Features.Transaction;

public record GetPartialTradedMemorabiliaTransactionPaged(PageInfo PageInfo,
    MemorabiliaSearchCriteria Filter = null)
    : IQuery<MemorabiliaTransactionsModel>
{
    public class Handler(IMemorabiliaTransactionRepository memorabiliaTransactionRepository,
                         IApplicationStateService applicationStateService) 
        : QueryHandler<GetPartialTradedMemorabiliaTransactionPaged, MemorabiliaTransactionsModel>
    {
        protected override async Task<MemorabiliaTransactionsModel> Handle(GetPartialTradedMemorabiliaTransactionPaged query)
        {
            PagedResult<Entity.MemorabiliaTransaction> result
                = await memorabiliaTransactionRepository.GetAllPartialTrades(query.PageInfo,
                                                                             applicationStateService.CurrentUser.Id,
                                                                             query.Filter ?? new MemorabiliaSearchCriteria());

            return new MemorabiliaTransactionsModel(result.Data, result.PageInfo);
        }
    }
}
