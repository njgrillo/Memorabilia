namespace Memorabilia.Application.Features.Transaction;

public record GetMemorabiliaTransactionTrades(int MemorabiliaTransactionId)
    : IQuery<Entity.MemorabiliaTransactionTrade[]>
{
    public class Handler(IMemorabiliaTransactionTradeRepository memorabiliaTransactionTradeRepository) 
        : QueryHandler<GetMemorabiliaTransactionTrades, Entity.MemorabiliaTransactionTrade[]>
    {
        protected override async Task<Entity.MemorabiliaTransactionTrade[]> Handle(GetMemorabiliaTransactionTrades query)
            => await memorabiliaTransactionTradeRepository.GetAll(query.MemorabiliaTransactionId);
    }
}
