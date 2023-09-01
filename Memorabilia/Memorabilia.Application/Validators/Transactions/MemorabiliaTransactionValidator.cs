namespace Memorabilia.Application.Validators.Transactions;

public class MemorabiliaTransactionValidator 
    : AbstractValidator<SaveMemorabiliaTransaction.Command>
{
	public MemorabiliaTransactionValidator()
	{
        RuleFor(x => x.TransactionTypeId)
            .GreaterThan(0)
            .WithName("TransactionTypeId")
            .WithMessage("Transaction Type is required.");

        RuleForEach(x => x.Sales)
            .SetValidator(new MemorabiliaTransactionSaleValidator());

        RuleForEach(x => x.Trades)
            .SetValidator(new MemorabiliaTransactionTradeValidator());
    }
}
