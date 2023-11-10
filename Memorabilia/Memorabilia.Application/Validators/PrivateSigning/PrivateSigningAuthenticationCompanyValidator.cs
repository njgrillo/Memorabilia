namespace Memorabilia.Application.Validators.PrivateSigning;

public class PrivateSigningAuthenticationCompanyValidator : AbstractValidator<PrivateSigningAuthenticationCompanyEditModel>
{
	public PrivateSigningAuthenticationCompanyValidator()
	{
        RuleFor(x => x.AuthenticationCompanyId)
            .GreaterThan(0)
            .WithName("AuthenticationCompanyId")
            .WithMessage("Authentication Company Id is required.");

        RuleFor(x => x.Cost)
            .GreaterThan(0)
            .NotNull()
            .WithName("Cost")
            .WithMessage("Cost is required.");
    }
}
