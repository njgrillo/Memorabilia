namespace Memorabilia.Application.Validators.PrivateSigning;

public class PrivateSigningPriceValidator : AbstractValidator<PrivateSigningPersonDetailEditModel>
{
    public PrivateSigningPriceValidator()
    {
        RuleFor(x => x.Person.Id)
            .GreaterThan(0)
            .WithName("Person")
            .WithMessage("Person is required.");

        RuleFor(x => x.PrivateSigningCustomItemTypeGroupDetail)
            .NotNull()
            .When(x => x.IsCustomType)
            .WithName("PrivateSigningCustomItemTypeGroupDetail")
            .WithMessage("Item Group is required.");

        RuleFor(x => x.PrivateSigningItemGroup)
            .NotNull()
            .When(x => !x.IsCustomType)
            .WithName("PrivateSigningItemGroup")
            .WithMessage("Item Group is required.");

        RuleFor(x => x.PrivateSigningItemGroup.Id)
            .GreaterThan(0)
            .When(x => x.PrivateSigningItemGroup is not null && !x.IsCustomType)
            .WithName("PrivateSigningItemGroup")
            .WithMessage("Item Group is required.");
    }
}
