namespace Memorabilia.Application.Validators.ProposeTrade;

public class ProposeTradeValidator : AbstractValidator<AddProposeTrade.Command>
{
    public ProposeTradeValidator()
    {
        RuleFor(x => x.ReceiveItemsCount)
            .GreaterThan(0)
            .WithName("ReceiveItems")
            .WithMessage("Must specify at least one item to receive.");

        RuleFor(x => x.SendItemsCount)
            .GreaterThan(0)
            .WithName("SendItems")
            .WithMessage("Must specify at least one item to send.");
    }
}
