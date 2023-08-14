namespace Memorabilia.Application.Validators.ThroughTheMail;

public class ThroughTheMailValidator : AbstractValidator<SaveThroughTheMail.Command>
{
	public ThroughTheMailValidator()
	{
        RuleFor(x => x.PersonId)
            .GreaterThan(0)
            .WithName("PersonId")
            .WithMessage("Person is required.");

        //RuleForEach(x => x.Thr)
        //    .SetValidator(new ProjectPersonValidator());
    }
}
