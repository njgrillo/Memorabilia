namespace Memorabilia.Application.Validators.MountRushmore;

public class MountRushmorePersonValidator : AbstractValidator<MountRushmorePersonEditModel>
{
    public MountRushmorePersonValidator()
    {
        RuleFor(x => x.PersonId)
            .GreaterThan(0)
            .WithName("Person")
            .WithMessage("Person is required.");

        RuleFor(x => x.PositionId)
            .GreaterThan(0)
            .WithName("Position")
            .WithMessage("Position is required.");
    }
}
