namespace Memorabilia.Application.Validators.PrivateSigning.Promoter.CustomItemGroups;

public class CustomItemTypeGroupValidator : AbstractValidator<CustomItemTypeGroupEditModel>
{
    public CustomItemTypeGroupValidator()
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
    }
}
