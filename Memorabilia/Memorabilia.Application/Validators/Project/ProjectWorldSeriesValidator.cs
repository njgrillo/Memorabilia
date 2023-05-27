namespace Memorabilia.Application.Validators.Project;

public class ProjectWorldSeriesValidator : AbstractValidator<Domain.Entities.ProjectWorldSeries>
{
    public ProjectWorldSeriesValidator(int projectTypeId)
    {
        var projectType = Domain.Constants.ProjectType.Find(projectTypeId);

        if (projectType != Domain.Constants.ProjectType.WorldSeries)
            return;

        RuleFor(x => x.TeamId)
            .GreaterThan(0)
            .WithName("TeamId")
            .WithMessage("Team is required.");

        RuleFor(x => x.Year)
           .GreaterThanOrEqualTo(1900)
           .LessThanOrEqualTo(DateTime.UtcNow.Year)
           .When(x => x.Year.HasValue)
           .WithName("World Series Year")
           .WithMessage($"World Series Year must be between 1900 and {DateTime.UtcNow.Year}.");
    }
}
