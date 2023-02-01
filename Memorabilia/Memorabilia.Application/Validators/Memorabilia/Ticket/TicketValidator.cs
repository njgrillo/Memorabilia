namespace Memorabilia.Application.Validators.Memorabilia.Ticket;

public class TicketValidator : AbstractValidator<SaveTicket.Command>
{
	public TicketValidator()
	{
        RuleFor(x => x.LevelTypeId)
            .GreaterThan(0)
            .WithName("Level")
            .WithMessage("Level is required.");

        RuleFor(x => x.SizeId)
            .GreaterThan(0)
            .WithName("Size")
            .WithMessage("Size is required.");
    }
}
