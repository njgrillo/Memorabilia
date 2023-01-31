namespace Memorabilia.Application.Validators.Memorabilia;

public class MemorabiliaItemValidator : AbstractValidator<SaveMemorabiliaItem.Command>
{
	public MemorabiliaItemValidator()
	{
        RuleFor(x => x.AcquisitionTypeId)
            .GreaterThan(0)
            .When(x => x.AcquiredDate.HasValue || x.Cost.HasValue || x.PurchaseTypeId.HasValue)
            .WithName("Acquisition Type")
            .WithMessage("Acquisition Type is required.");

        RuleFor(x => x.AcquisitionTypeId)
            .Must(x => x == Domain.Constants.AcquisitionType.Purchase.Id)
            .When(x => x.Cost.HasValue || x.PurchaseTypeId.HasValue)
            .WithName("Acquisition Type")
            .WithMessage("Acquisition Type must be Purchase when Cost or Purchase Type is entered.");

        RuleFor(x => x.ItemTypeId)
			.GreaterThan(0)
			.WithName("Item Type")
			.WithMessage("Item Type is required.");

        RuleFor(x => x.PrivacyTypeId)
            .GreaterThan(0)
            .WithName("Privacy Type")
            .WithMessage("Privacy Type is required.");        
    }
}
