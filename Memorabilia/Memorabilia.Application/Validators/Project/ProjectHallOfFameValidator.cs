namespace Memorabilia.Application.Validators.Project;

public class ProjectHallOfFameValidator : AbstractValidator<Domain.Entities.ProjectHallOfFame>
{
    public ProjectHallOfFameValidator(int projectTypeId)
    {
        var projectType = Domain.Constants.ProjectType.Find(projectTypeId);

        if (projectType != Domain.Constants.ProjectType.HallOfFame)
            return;

        RuleFor(x => x.SportLeagueLevelId)
            .GreaterThan(0)
            .WithName("SportLeagueLevelId")
            .WithMessage("Sport League Level is required.");

        RuleFor(x => x.Year)
           .GreaterThanOrEqualTo(1930)
           .LessThanOrEqualTo(DateTime.UtcNow.Year)
           .When(x => x.Year.HasValue)
           .WithName("Hall of Fame Year")
           .WithMessage($"Hall of Fame Year must be between 1930 and {DateTime.UtcNow.Year}.");
    }
}
