namespace Memorabilia.Application.Validators.PrivateSigning;

public class PrivateSigningExcludedItemTypeValidator : AbstractValidator<PrivateSigningPersonExcludeItemTypeEditModel>
{
    public PrivateSigningExcludedItemTypeValidator()
    {
        RuleFor(x => x.ItemType)
            .NotNull()
            .WithName("ItemType")
            .WithMessage("Item Type is required.");

        RuleFor(x => x.ItemType.Id)
            .GreaterThan(0)
            .When(x => x.ItemType is not null)
            .WithName("ItemType")
            .WithMessage("Item Type is required.");

        RuleFor(x => x.Person.Id)
            .GreaterThan(0)
            .WithName("Person")
            .WithMessage("Person is required.");
    }
}
