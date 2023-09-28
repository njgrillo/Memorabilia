namespace Memorabilia.Application.Validators.SignatureIdentification;

public class SignatureIdentificationPersonValidator : AbstractValidator<SaveSignatureIdentificationPerson.Command>
{
	public SignatureIdentificationPersonValidator()
	{
        RuleFor(x => x.CreatedUserId)
            .GreaterThan(0)
            .WithName("CreatedUserId")
            .WithMessage("CreatedUserId is required.");

        RuleFor(x => x.PersonId)
            .GreaterThan(0)
            .WithName("PersonId")
            .WithMessage("Person is required.");
    }
}
