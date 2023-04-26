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
    }
}
