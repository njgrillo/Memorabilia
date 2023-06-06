namespace Memorabilia.Application.Validators.Memorabilia;

public class MemorabiliaItemValidator : AbstractValidator<SaveMemorabiliaItem.Command>
{
	public MemorabiliaItemValidator()
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

        RuleFor(x => x.AcquisitionTypeId)
            .GreaterThan(0)
            .When(x => x.AcquiredDate.HasValue || x.Cost.HasValue || x.PurchaseTypeId.HasValue)
            .WithName("Acquisition Type")
            .WithMessage("Acquisition Type is required.");

        RuleFor(x => x.AcquisitionTypeId)
            .Must(x => x == Constant.AcquisitionType.Purchase.Id)
            .When(x => x.Cost.HasValue || x.PurchaseTypeId.HasValue)
            .WithName("Acquisition Type")
            .WithMessage("Acquisition Type must be Purchase when Cost or Purchase Type is entered.");

        RuleFor(x => x.Cost)
            .LessThanOrEqualTo(9999999999)
            .When(x => x.Cost.HasValue)
            .WithName("Cost")
            .WithMessage("Cost must be less than or equal to 999,999,999.");

        RuleFor(x => x.Denominator)
            .LessThanOrEqualTo(int.MaxValue)
            .When(x => x.Denominator.HasValue)
            .WithName("Denominator")
            .WithMessage($"Right Serial # must be {int.MaxValue} or less.");

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

        RuleFor(x => x.ItemTypeId)
			.GreaterThan(0)
			.WithName("Item Type")
			.WithMessage("Item Type is required.");

        RuleFor(x => x.Note)
            .MaximumLength(8000)
            .When(x => !x.Note.IsNullOrEmpty())
            .WithName("Note")
            .WithMessage("Note must be 8,000 characters or less.");

        RuleFor(x => x.Numerator)
            .LessThanOrEqualTo(int.MaxValue)
            .When(x => x.Numerator.HasValue)
            .WithName("Numerator")
            .WithMessage($"Left Serial # must be {int.MaxValue} or less.");

        RuleFor(x => x.PrivacyTypeId)
            .GreaterThan(0)
            .WithName("Privacy Type")
            .WithMessage("Privacy Type is required.");        
    }
}
