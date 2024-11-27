namespace Memorabilia.Application.Validators.PrivateSigning.Promoter.CustomItemGroups;

public class CustomItemGroupValidator : AbstractValidator<CustomItemGroupEditModel>
{
    public CustomItemGroupValidator()
    {
        RuleFor(x => x.CreatedDate)
            .NotNull()
            .WithName("CreatedDate")
            .WithMessage("Created Date is required.");

        RuleFor(x => x.Name)
            .MaximumLength(200)
            .WithName("Name")
            .WithMessage("Name must be 200 characters or less.");

        RuleForEach(x => x.Items)
            .SetValidator(new CustomItemTypeGroupValidator());
    }
}
