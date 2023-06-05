namespace Memorabilia.Application.Validators.Autograph;

public class AuthenticationValidator : AbstractValidator<AuthenticationEditModel>
{
	public AuthenticationValidator()
	{
        RuleFor(x => x.AuthenticationCompanyId)
            .GreaterThan(0)
            .WithName("Authentication Company")
            .WithMessage("Authentication Company is required.");

        RuleFor(x => x.Verification)
            .MaximumLength(50)
            .WithName("Verification")
            .WithMessage("Verification must be 50 characters or less.");        
    }
}
