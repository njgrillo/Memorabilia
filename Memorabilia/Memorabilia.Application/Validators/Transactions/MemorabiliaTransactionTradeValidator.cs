namespace Memorabilia.Application.Validators.Transactions;

public class MemorabiliaTransactionTradeValidator 
    : AbstractValidator<MemorabiliaTransactionTradeEditModel>
{
    public MemorabiliaTransactionTradeValidator()
    {
        RuleFor(x => x.MemorabiliaId)
            .GreaterThan(0)
            .WithName("MemorabiliaId")
            .WithMessage("Memorabilia is required.");

        RuleFor(x => x.TransactionTradeTypeId)
            .GreaterThan(0)
            .WithName("TransactionTradeTypeId")
            .WithMessage("Transaction Trade Type is required.");
    }
}
