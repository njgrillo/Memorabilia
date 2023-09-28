namespace Memorabilia.Application.Validators.SignatureIdentification;

public class SignatureIdentificationImageValidator : AbstractValidator<SignatureIdentificationImageEditModel>
{
	public SignatureIdentificationImageValidator()
	{
        RuleFor(x => x.FileName)
            .NotEmpty()
            .NotNull()
            .WithName("FileName")
            .WithMessage("FileName is required.");

        RuleFor(x => x.FileName)
            .MaximumLength(100)
            .WithName("FileName")
            .WithMessage("FileName must be 100 characters or less.");
    }
}
