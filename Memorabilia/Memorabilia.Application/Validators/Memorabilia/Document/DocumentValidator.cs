namespace Memorabilia.Application.Validators.Memorabilia.Document;

public class DocumentValidator : AbstractValidator<SaveDocument.Command>
{
	public DocumentValidator()
	{
        RuleFor(x => x.SizeId)
            .GreaterThan(0)
            .WithName("Size")
            .WithMessage("Size is required.");
    }
}
