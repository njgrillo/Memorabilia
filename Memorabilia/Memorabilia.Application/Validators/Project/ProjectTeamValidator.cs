namespace Memorabilia.Application.Validators.Project;

public class ProjectTeamValidator : AbstractValidator<Domain.Entities.ProjectTeam>
{
    public ProjectTeamValidator(int projectTypeId)
    {
        var projectType = Constant.ProjectType.Find(projectTypeId);

        if (projectType != Constant.ProjectType.Team)
            return;

        RuleFor(x => x.TeamId)
            .GreaterThan(0)
            .WithName("TeamId")
            .WithMessage("Team is required.");

        RuleFor(x => x.Year)
           .GreaterThanOrEqualTo(1900)
           .LessThanOrEqualTo(DateTime.UtcNow.Year)
           .When(x => x.Year.HasValue)
           .WithName("Team Year")
           .WithMessage($"Team Year must be between 1900 and {DateTime.UtcNow.Year}.");
    }
}
