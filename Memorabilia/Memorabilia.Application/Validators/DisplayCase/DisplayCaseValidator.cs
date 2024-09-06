namespace Memorabilia.Application.Validators.DisplayCase;

public class DisplayCaseValidator : AbstractValidator<SaveDisplayCase.Command>
{
    public DisplayCaseValidator()
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

        RuleForEach(x => x.Dimensions)
            .SetValidator(new DisplayCaseDimensionValidator());

        RuleForEach(x => x.Memorabilias)
            .SetValidator(new DisplayCaseMemorabiliaValidator());
    }
}
