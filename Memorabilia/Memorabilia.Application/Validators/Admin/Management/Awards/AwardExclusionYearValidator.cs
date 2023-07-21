namespace Memorabilia.Application.Validators.Admin.Management.Awards;

public class AwardExclusionYearValidator : AbstractValidator<AwardExclusionYearEditModel>
{
	public AwardExclusionYearValidator()
	{
        RuleFor(x => x.Reason)
            .MaximumLength(1000)
            .WithName("Reason")
            .WithMessage("Reason must be 1,000 characters or less.");

        RuleFor(x => x.Year)
            .GreaterThan(0)
            .WithName("Year")
            .WithMessage("Year is required.");
    }
}
