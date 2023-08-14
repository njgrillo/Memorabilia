namespace Memorabilia.Application.Validators.Autograph;

public class AutographValidator : AbstractValidator<SaveAutograph.Command>
{
	public AutographValidator()
	{
        RuleFor(x => x.AcquiredDate)
            .GreaterThanOrEqualTo(DateTime.MinValue)
            .When(x => x.AcquiredDate.HasValue)
            .WithName("Acquired Date")
            .WithMessage($"Acquired Date cannot be before {DateTime.MinValue}.");

        RuleFor(x => x.AcquiredDate)
            .LessThanOrEqualTo(DateTime.UtcNow)
            .When(x => x.AcquiredDate.HasValue)
            .WithName("Acquired Date")
            .WithMessage("Acquired Date cannot be in the future.");

        RuleFor(x => x.ColorId)
            .GreaterThan(0)
            .WithName("Color")
            .WithMessage("Color is required.");

        RuleFor(x => x.ConditionId)
            .GreaterThan(0)
            .WithName("Condition")
            .WithMessage("Condition is required.");

        RuleFor(x => x.Cost)
            .GreaterThanOrEqualTo(0)
            .When(x => x.Cost.HasValue)
            .WithName("Cost")
            .WithMessage("Cost must be greater than or equal to 0.");

        RuleFor(x => x.Cost)
            .LessThanOrEqualTo(9999999999)
            .When(x => x.Cost.HasValue)
            .WithName("Cost")
            .WithMessage("Cost must be less than or equal to 999,999,999.");

        RuleFor(x => x.EstimatedValue)
            .GreaterThanOrEqualTo(0)
            .When(x => x.EstimatedValue.HasValue)
            .WithName("Estimated Value")
            .WithMessage("Estimated Value must be greater than or equal to 0.");

        RuleFor(x => x.EstimatedValue)
            .LessThanOrEqualTo(9999999999)
            .When(x => x.EstimatedValue.HasValue)
            .WithName("Estimated Value")
            .WithMessage("Estimated Value must be less than or equal to 999,999,999.");

        RuleFor(x => x.Grade)
            .GreaterThanOrEqualTo(0)
            .When(x => x.Grade.HasValue)
            .WithName("Grade")
            .WithMessage("Grade must be 0 or greater.");

        RuleFor(x => x.Grade)
            .LessThanOrEqualTo(100)
            .When(x => x.Grade.HasValue)
            .WithName("Grade")
            .WithMessage("Grade must be 100 or less.");

        RuleFor(x => x.Note)
            .MaximumLength(8000)
            .When(x => !x.Note.IsNullOrEmpty())
            .WithName("Note")
            .WithMessage("Note must be 8,000 characters or less.");

        RuleFor(x => x.PersonId)
            .GreaterThan(0)
            .WithName("Person")
            .WithMessage("Person is required.");

        RuleFor(x => x.PersonalizationText)
            .MaximumLength(200)
            .WithName("Personalization Text")
            .WithMessage("Personalization Text must be 200 characters or less.");

        RuleFor(x => x.WritingInstrumentId)
            .GreaterThan(0)
            .WithName("Writing Instrument")
            .WithMessage("Writing Instrument is required.");
    }
}
