namespace Memorabilia.Application.Validators.User;

public class UserValidator : AbstractValidator<UserEditModel>
{
	public UserValidator()
	{
        RuleFor(x => x.EmailAddress)
            .MaximumLength(100)
            .WithName("Email Address")
            .WithMessage("Email Address must be 100 characters or less.");

        RuleFor(x => x.EmailAddress)
            .NotEmpty()
            .NotNull()
            .WithName("Email Address")
            .WithMessage("Email Address is required.");

        RuleFor(x => x.FirstName)
            .MaximumLength(50)
            .WithName("First Name")
            .WithMessage("First Name must be 50 characters or less.");

        RuleFor(x => x.FirstName)
            .NotEmpty()
            .NotNull()
            .WithName("First Name")
            .WithMessage("First Name is required.");

        RuleFor(x => x.LastName)
            .MaximumLength(50)
            .WithName("Last Name")
            .WithMessage("Last Name must be 50 characters or less.");

        RuleFor(x => x.LastName)
            .NotEmpty()
            .NotNull()
            .WithName("Last Name")
            .WithMessage("Last Name is required.");
    }
}
