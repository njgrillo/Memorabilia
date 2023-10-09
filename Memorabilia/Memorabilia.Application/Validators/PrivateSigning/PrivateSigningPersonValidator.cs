namespace Memorabilia.Application.Validators.PrivateSigning;

public class PrivateSigningPersonValidator : AbstractValidator<PrivateSigningPersonEditModel>
{
	public PrivateSigningPersonValidator()
	{
        RuleFor(x => x.Note)
            .MaximumLength(3000)
            .WithName("Note")
            .WithMessage("Note must be 3000 characters or less.");

        RuleFor(x => x.PersonId)
            .GreaterThan(0)
            .WithName("PersonId")
            .WithMessage("Person Id is required.");

        RuleFor(x => x.PrivateSigningId)
            .GreaterThan(0)
            .WithName("PrivateSigningId")
            .WithMessage("Private Signing Id is required.");

        //Spots Available
        //Spots Confirmed
        //Spots Reserved
    }
}
