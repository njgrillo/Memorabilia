namespace Memorabilia.Application.Validators.Admin.Management.Awards;

public class AwardManagementValidator : AbstractValidator<SaveAwardManagement.Command>
{
    public AwardManagementValidator()
    {
        RuleFor(x => x.AwardManagement.AwardType.Id)
            .GreaterThan(0)
            .WithName("AwardType")
            .WithMessage("Award Type is required.");

        RuleFor(x => x.AwardManagement.BeginYear)
            .GreaterThan(0)
            .WithName("BeginYear")
            .WithMessage("Begin Year must be greater than 0.");

        RuleFor(x => x.AwardManagement.EndYear)
            .GreaterThanOrEqualTo(x => x.AwardManagement.BeginYear)
            .When(x => x.AwardManagement.EndYear.HasValue)
            .WithName("End Year")
            .WithMessage("End Year cannot be before Begin Year.");

        RuleFor(x => x.AwardManagement.NumberOfWinners)
           .GreaterThan(0)
           .WithName("NumberOfWinners")
           .WithMessage("Number of Winners must be greater than 0.");

        RuleFor(x => x.AwardManagement.MonthAwarded)
           .GreaterThan(0)
           .When(x => x.AwardManagement.MonthAwarded.HasValue)
           .WithName("MonthAwarded")
           .WithMessage("Month Awarded must be greater than 0.");

        RuleFor(x => x.AwardManagement.MonthAwarded)
           .LessThan(13)
           .When(x => x.AwardManagement.MonthAwarded.HasValue)
           .WithName("MonthAwarded")
           .WithMessage("Month Awarded must be less than 13.");

        RuleForEach(x => x.AwardManagement.ExclusionYears)
            .SetValidator(new AwardExclusionYearValidator());
    }
}
