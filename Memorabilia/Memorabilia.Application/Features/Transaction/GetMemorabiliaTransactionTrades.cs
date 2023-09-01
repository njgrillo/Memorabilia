namespace Memorabilia.Application.Features.Transaction;

public record GetMemorabiliaTransactionTrades(int MemorabiliaTransactionId)
    : IQuery<Entity.MemorabiliaTransactionTrade[]>
{
    public class Handler : QueryHandler<GetMemorabiliaTransactionTrades, Entity.MemorabiliaTransactionTrade[]>
    {
        private readonly IMemorabiliaTransactionTradeRepository _memorabiliaTransactionTradeRepository;

        public Handler(IMemorabiliaTransactionTradeRepository memorabiliaTransactionTradeRepository)
        {
            _memorabiliaTransactionTradeRepository = memorabiliaTransactionTradeRepository;
        }

        protected override async Task<Entity.MemorabiliaTransactionTrade[]> Handle(GetMemorabiliaTransactionTrades query)
            => await _memorabiliaTransactionTradeRepository.GetAll(query.MemorabiliaTransactionId);
    }
}
