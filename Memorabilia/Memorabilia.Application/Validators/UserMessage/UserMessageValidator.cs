namespace Memorabilia.Application.Validators.UserMessage;

public class UserMessageValidator : AbstractValidator<AddUserMessage.Command>
{
	public UserMessageValidator()
	{
        RuleFor(x => x.Message)
            .MaximumLength(8000)
            .WithName("Message")
            .WithMessage("Message must be 8000 characters or less.");

        RuleFor(x => x.Message)
            .NotEmpty()
            .NotNull()
            .WithName("Message")
            .WithMessage("Message is required.");

        RuleFor(x => x.ReceiverUserId)
            .GreaterThan(0)
            .WithName("ReceiverUser")
            .WithMessage("Receiver User is required.");

        RuleFor(x => x.SenderUserId)
            .GreaterThan(0)
            .WithName("SenderUser")
            .WithMessage("Sender User is required.");

        RuleFor(x => x.Subject)
            .MaximumLength(300)
            .WithName("Subject")
            .WithMessage("Subject must be 300 characters or less.");

        RuleFor(x => x.Subject)
            .NotEmpty()
            .NotNull()
            .WithName("Subject")
            .WithMessage("Subject is required.");
    }
}
