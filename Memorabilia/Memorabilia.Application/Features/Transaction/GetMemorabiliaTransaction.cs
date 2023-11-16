namespace Memorabilia.Application.Features.Transaction;

public record GetMemorabiliaTransaction(int Id)
    : IQuery<MemorabiliaTransactionEditModel>
{
    public class Handler(IMemorabiliaTransactionRepository memorabiliaTransactionRepository,
                         IMemorabiliaTransactionSaleRepository memorabiliaTransactionSaleRepository,
                         IMemorabiliaTransactionTradeRepository memorabiliaTransactionTradeRepository) 
        : QueryHandler<GetMemorabiliaTransaction, MemorabiliaTransactionEditModel>
    {
        protected override async Task<MemorabiliaTransactionEditModel> Handle(GetMemorabiliaTransaction query)
        {
            Entity.MemorabiliaTransaction memorabiliaTransaction 
                = await memorabiliaTransactionRepository.Get(query.Id);

            MemorabiliaTransactionEditModel editModel = new(memorabiliaTransaction);

            Entity.MemorabiliaTransactionSale[] memorabiliaTransactionSales
                = await memorabiliaTransactionSaleRepository.GetAll(query.Id);

            if (memorabiliaTransactionSales.Length != 0)
                editModel.Sales = memorabiliaTransactionSales.Select(sale => new MemorabiliaTransactionSaleEditModel(sale))
                                                             .ToList();

            Entity.MemorabiliaTransactionTrade[] memorabiliaTransactionTrades
                = await memorabiliaTransactionTradeRepository.GetAll(query.Id);

            if (memorabiliaTransactionTrades.Length != 0)
                editModel.Trades = memorabiliaTransactionTrades.Select(trade => new MemorabiliaTransactionTradeEditModel(trade))
                                                               .ToList();

            return editModel;
        }
    }
}
