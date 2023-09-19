namespace Memorabilia.Application.Features.Transaction;

public class SaveMemorabiliaTransaction
{
    public class Handler : CommandHandler<Command>
    {
        private readonly IApplicationStateService _applicationStateService;
        private readonly IMemorabiliaTransactionRepository _memorabiliaTransactionRepository;

        public Handler(IApplicationStateService applicationStateService,
            IMemorabiliaTransactionRepository memorabiliaTransactionRepository)
        {
            _applicationStateService = applicationStateService;
            _memorabiliaTransactionRepository = memorabiliaTransactionRepository;
        }

        protected override async Task Handle(Command command)
        {
            Entity.MemorabiliaTransaction memorabiliaTransaction;

            if (command.IsNew)
            {
                memorabiliaTransaction = new Entity.MemorabiliaTransaction(command.TransactionTypeId,
                                                                           command.TransactionDate,
                                                                           _applicationStateService.CurrentUser.Id);

                SetMemorabiliaTransactionSales(memorabiliaTransaction, command);
                SetMemorabiliaTransactionTrades(memorabiliaTransaction, command);

                await _memorabiliaTransactionRepository.Add(memorabiliaTransaction);

                command.Id = memorabiliaTransaction.Id;

                return;
            }

            memorabiliaTransaction = await _memorabiliaTransactionRepository.Get(command.Id);

            if (command.IsDeleted)
            {
                DeleteMemorabiliaTransactionSales(memorabiliaTransaction, command);
                DeleteMemorabiliaTransactionTrades(memorabiliaTransaction, command);

                await _memorabiliaTransactionRepository.Delete(memorabiliaTransaction);

                return;
            }

            memorabiliaTransaction.Set(command.TransactionDate);

            SetMemorabiliaTransactionSales(memorabiliaTransaction, command);
            SetMemorabiliaTransactionTrades(memorabiliaTransaction, command);

            DeleteMemorabiliaTransactionSales(memorabiliaTransaction, command);
            DeleteMemorabiliaTransactionTrades(memorabiliaTransaction, command);

            await _memorabiliaTransactionRepository.Update(memorabiliaTransaction);
        }

        private static void DeleteMemorabiliaTransactionSales(Entity.MemorabiliaTransaction memorabiliaTransaction, 
                                                              Command command)
        {
            if (!command.DeleteMemorabiliaTransactionSaleIds.Any())
                return;

            memorabiliaTransaction.RemoveSales(command.DeleteMemorabiliaTransactionSaleIds);
        }

        private static void DeleteMemorabiliaTransactionTrades(Entity.MemorabiliaTransaction memorabiliaTransaction,
                                                               Command command)
        {
            if (!command.DeleteMemorabiliaTransactionTradeIds.Any())
                return;

            memorabiliaTransaction.RemoveTrades(command.DeleteMemorabiliaTransactionTradeIds);
        }

        private static void SetMemorabiliaTransactionSales(Entity.MemorabiliaTransaction memorabiliaTransaction,
                                                           Command command)
        {
            foreach (MemorabiliaTransactionSaleEditModel memorabiliaTransactionSale in command.Sales.Where(sale => !sale.IsDeleted))
            {
                memorabiliaTransaction.SetSale(memorabiliaTransactionSale.Id,
                                               memorabiliaTransactionSale.MemorabiliaId,
                                               memorabiliaTransactionSale.SaleAmount ?? 0);
            }
        }

        private static void SetMemorabiliaTransactionTrades(Entity.MemorabiliaTransaction memorabiliaTransaction,
                                                           Command command)
        {
            foreach (MemorabiliaTransactionTradeEditModel memorabiliaTransactionTrade in command.Trades.Where(trade => !trade.IsDeleted))
            {
                memorabiliaTransaction.SetTrade(memorabiliaTransactionTrade.Id,    
                                                memorabiliaTransactionTrade.MemorabiliaId,
                                                memorabiliaTransactionTrade.TransactionTradeTypeId,
                                                memorabiliaTransactionTrade.CashIncludedAmount,
                                                memorabiliaTransactionTrade.CashIncludedTypeId > 0 ? memorabiliaTransactionTrade.CashIncludedTypeId : null);
            }
        }
    }

    public class Command : DomainCommand, ICommand
    {
        private readonly MemorabiliaTransactionEditModel _editModel;

        public Command(MemorabiliaTransactionEditModel editModel)
        {
            _editModel = editModel;

            Id = _editModel.Id;
        }

        public int[] DeleteMemorabiliaTransactionSaleIds
            => _editModel.IsDeleted
                ? _editModel.Sales
                            .Select(item => item.Id)
                            .ToArray()
                : _editModel.Sales
                            .Where(item => item.IsDeleted)
                            .Select(item => item.Id)
                            .ToArray();

        public int[] DeleteMemorabiliaTransactionTradeIds
            => _editModel.IsDeleted
                ? _editModel.Trades
                            .Select(item => item.Id)
                            .ToArray()
                : _editModel.Trades
                            .Where(item => item.IsDeleted)
                            .Select(item => item.Id)
                            .ToArray();

        public int Id { get; set; }

        public bool IsDeleted
            => _editModel.IsDeleted;

        public bool IsNew
            => _editModel.IsNew;

        public MemorabiliaTransactionSaleEditModel[] Sales
            => _editModel.Sales
                         .Where(item => !item.IsDeleted)
                         .ToArray();

        public MemorabiliaTransactionTradeEditModel[] Trades
            => _editModel.Trades
                         .Where(item => !item.IsDeleted)
                         .ToArray();

        public DateTime? TransactionDate
            => _editModel.TransactionDate;

        public int TransactionTypeId
            => _editModel.TransactionTypeId;      

        public int UserId
            => _editModel.UserId;
    }
}
