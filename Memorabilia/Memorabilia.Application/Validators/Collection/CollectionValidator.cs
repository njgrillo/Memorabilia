namespace Memorabilia.Application.Validators.Collection;

public class CollectionValidator : AbstractValidator<SaveCollection.Command>
{
	public CollectionValidator()
	{
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithName("Name")
            .WithMessage("Name is required.");

        RuleFor(x => x.Name)
            .MaximumLength(250)
            .WithName("Name")
            .WithMessage("Name must be 250 characters or less.");

        RuleFor(x => x.Description)
            .MaximumLength(1000)
            .WithName("Description")
            .WithMessage("Description must be 1000 characters or less.");
    }
}
