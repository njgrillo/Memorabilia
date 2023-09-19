namespace Memorabilia.Application.Validators.Forum;

public class ForumValidator : AbstractValidator<SaveForumTopic.Command>
{
	public ForumValidator()
	{
        RuleFor(x => x.ForumCategoryId)
            .GreaterThan(0)
            .WithName("ForumCategoryId")
            .WithMessage("Category is required.");

        RuleFor(x => x.Message)
           .NotEmpty()
           .NotNull()
           .WithName("Message")
           .WithMessage("Message is required.");

        RuleFor(x => x.Message)
            .MaximumLength(300)
            .WithName("Message")
            .WithMessage("Message must be 8000 characters or less.");

        RuleFor(x => x.Subject)
           .NotEmpty()
           .NotNull()
           .WithName("Subject")
           .WithMessage("Subject is required.");

        RuleFor(x => x.Subject)
            .MaximumLength(300)
            .WithName("Subject")
            .WithMessage("Subject must be 300 characters or less.");
    }
}
