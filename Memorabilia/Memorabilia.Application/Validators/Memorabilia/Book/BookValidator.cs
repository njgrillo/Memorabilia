namespace Memorabilia.Application.Validators.Memorabilia.Book;

public class BookValidator : AbstractValidator<SaveBook.Command>
{
	public BookValidator()
	{
        RuleFor(x => x.Edition)
            .MaximumLength(5)
            .When(x => !x.Edition.IsNullOrEmpty())
            .WithName("Edition")
            .WithMessage("Edition cannot be more than 5 characters.");

        RuleFor(x => x.Publisher)
            .MaximumLength(200)
            .When(x => !x.Publisher.IsNullOrEmpty())
            .WithName("Publisher")
            .WithMessage("Publisher cannot be more than 200 characters.");

        RuleFor(x => x.Title)
            .NotNull()
            .NotEmpty()
            .WithName("Title")
            .WithMessage("Title is required.");

        RuleFor(x => x.Title)
            .MaximumLength(200)
            .WithName("Title")
            .WithMessage("Title cannot be more than 200 characters.");
    }
}
