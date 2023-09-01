namespace Memorabilia.Application.Features.Transaction;

public record GetMemorabiliaTransaction(int Id)
    : IQuery<MemorabiliaTransactionEditModel>
{
    public class Handler : QueryHandler<GetMemorabiliaTransaction, MemorabiliaTransactionEditModel>
    {
        private readonly IMemorabiliaTransactionRepository _memorabiliaTransactionRepository;
        private readonly IMemorabiliaTransactionSaleRepository _memorabiliaTransactionSaleRepository;
        private readonly IMemorabiliaTransactionTradeRepository _memorabiliaTransactionTradeRepository;

        public Handler(IMemorabiliaTransactionRepository memorabiliaTransactionRepository,
            IMemorabiliaTransactionSaleRepository memorabiliaTransactionSaleRepository, 
            IMemorabiliaTransactionTradeRepository memorabiliaTransactionTradeRepository)
        {
            _memorabiliaTransactionRepository = memorabiliaTransactionRepository;
            _memorabiliaTransactionSaleRepository = memorabiliaTransactionSaleRepository;
            _memorabiliaTransactionTradeRepository = memorabiliaTransactionTradeRepository;
        }

        protected override async Task<MemorabiliaTransactionEditModel> Handle(GetMemorabiliaTransaction query)
        {
            Entity.MemorabiliaTransaction memorabiliaTransaction 
                = await _memorabiliaTransactionRepository.Get(query.Id);

            MemorabiliaTransactionEditModel editModel = new(memorabiliaTransaction);

            Entity.MemorabiliaTransactionSale[] memorabiliaTransactionSales
                = await _memorabiliaTransactionSaleRepository.GetAll(query.Id);

            if (memorabiliaTransactionSales.Any())
                editModel.Sales = memorabiliaTransactionSales.Select(sale => new MemorabiliaTransactionSaleEditModel(sale))
                                                             .ToList();

            Entity.MemorabiliaTransactionTrade[] memorabiliaTransactionTrades
                = await _memorabiliaTransactionTradeRepository.GetAll(query.Id);

            if (memorabiliaTransactionTrades.Any())
                editModel.Trades = memorabiliaTransactionTrades.Select(trade => new MemorabiliaTransactionTradeEditModel(trade))
                                                               .ToList();

            return editModel;
        }
    }
}
