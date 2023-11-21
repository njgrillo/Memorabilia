namespace Memorabilia.Application.Features.Transaction;

public record GetTradedMemorabiliaTransactionPaged(PageInfo PageInfo,
                                                   MemorabiliaSearchCriteria Filter = null)
    : IQuery<MemorabiliaTransactionsModel>
{
    public class Handler(IMemorabiliaTransactionRepository memorabiliaTransactionRepository,
                         IApplicationStateService applicationStateService) 
        : QueryHandler<GetTradedMemorabiliaTransactionPaged, MemorabiliaTransactionsModel>
    {
        protected override async Task<MemorabiliaTransactionsModel> Handle(GetTradedMemorabiliaTransactionPaged query)
        {
            PagedResult<Entity.MemorabiliaTransaction> result
                = await memorabiliaTransactionRepository.GetAllTrades(query.PageInfo,
                                                                      applicationStateService.CurrentUser.Id,
                                                                      query.Filter ?? new MemorabiliaSearchCriteria());

            return new MemorabiliaTransactionsModel(result.Data, result.PageInfo);
        }
    }
}
