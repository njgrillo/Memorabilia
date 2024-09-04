namespace Memorabilia.Application.Validators.MountRushmore;

public class MountRushmoreValidator : AbstractValidator<SaveMountRushmore.Command>
{
    public MountRushmoreValidator()
    {
        RuleFor(x => x.Description)
            .NotEmpty()
            .WithName("Description")
            .WithMessage("Description is required.");

        RuleFor(x => x.Name)
            .NotEmpty()
            .WithName("Name")
            .WithMessage("Name is required.");

        RuleFor(x => x.PrivacyTypeId)
            .GreaterThan(0)
            .WithName("Privacy Type")
            .WithMessage("Privacy Type is required.");

        RuleFor(x => x.UserId)
            .GreaterThan(0)
            .WithName("User")
            .WithMessage("User is required.");

        RuleForEach(x => x.People)
            .SetValidator(new MountRushmorePersonValidator());
    }
}
