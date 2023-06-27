namespace Memorabilia.Application.Validators.Admin.People;

public class PersonValidator : AbstractValidator<SavePerson.Command>
{
	public PersonValidator()
	{
        RuleFor(x => x.DeathDate)
            .GreaterThanOrEqualTo(x => x.BirthDate)
            .When(x => x.BirthDate.HasValue && x.DeathDate.HasValue)
            .WithName("Death Date")
            .WithMessage("Death Date cannot be before Birth Date.");

        RuleFor(x => x.DisplayName)
            .NotEmpty()
            .NotNull()
            .WithName("Display Name")
            .WithMessage("Display Name is required.");

        RuleFor(x => x.LegalName)
            .NotEmpty()
            .NotNull()
            .WithName("Legal Name")
            .WithMessage("Legal Name is required.");
    }
}
