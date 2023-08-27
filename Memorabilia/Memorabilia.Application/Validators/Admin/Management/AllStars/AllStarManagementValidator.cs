namespace Memorabilia.Application.Validators.Admin.Management.AllStars;

public class AllStarManagementValidator : AbstractValidator<SaveAllStarManagement.Command>
{
	public AllStarManagementValidator()
	{
        RuleFor(x => x.MonthPlayed)
            .GreaterThan(0)
            .WithName("MonthPlayed")
            .WithMessage("Month Played is required.");

        RuleFor(x => x.NumberOfAllStars)
            .GreaterThan(0)
            .WithName("NumberOfAllStars")
            .WithMessage("Number of All Stars is required.");

        RuleFor(x => x.SportLeagueLevelId)
            .GreaterThan(0)
            .WithName("SportLeagueLevel")
            .WithMessage("Sport League Level is required.");

        RuleFor(x => x.Year)
            .GreaterThan(0)
            .WithName("Year")
            .WithMessage("Year is required.");
    }
}
