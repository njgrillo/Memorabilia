namespace Memorabilia.Application.Validators.Memorabilia.PlayingCard;

public class PlayingCardValidator : AbstractValidator<SavePlayingCard.Command>
{
	public PlayingCardValidator()
	{
        RuleFor(x => x.SizeId)
            .GreaterThan(0)
            .WithName("Size")
            .WithMessage("Size is required.");
    }
}
