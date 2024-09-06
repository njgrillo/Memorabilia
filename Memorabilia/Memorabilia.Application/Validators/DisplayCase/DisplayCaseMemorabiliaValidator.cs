namespace Memorabilia.Application.Validators.DisplayCase;

public class DisplayCaseMemorabiliaValidator : AbstractValidator<DisplayCaseMemorabiliaEditModel>
{
    public DisplayCaseMemorabiliaValidator()
    {
        RuleFor(x => x.Memorabilia)
            .NotNull()
            .WithName("Memorabilia")
            .WithMessage("Memorabilia is required.");

        RuleFor(x => x.Memorabilia.Id)
            .GreaterThan(0)
            .WithName("Memorabilia")
            .WithMessage("Memorabilia is required.");

        RuleFor(x => x.XPosition)
            .GreaterThan(-1)
            .WithName("XPosition")
            .WithMessage("X Position is required.");

        RuleFor(x => x.YPosition)
            .GreaterThan(-1)
            .WithName("YPosition")
            .WithMessage("Y Position is required.");
    }
}
