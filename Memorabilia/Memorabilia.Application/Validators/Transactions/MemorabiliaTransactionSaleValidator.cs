namespace Memorabilia.Application.Validators.Transactions;

public class MemorabiliaTransactionSaleValidator 
    : AbstractValidator<MemorabiliaTransactionSaleEditModel>
{
	public MemorabiliaTransactionSaleValidator()
	{
        RuleFor(x => x.MemorabiliaId)
            .GreaterThan(0)
            .WithName("MemorabiliaId")
            .WithMessage("Memorabilia is required.");

        RuleFor(x => x.SaleAmount)
            .GreaterThan(0)
            .WithName("SaleAmount")
            .WithMessage("Sale Amount is required.");
    }
}
