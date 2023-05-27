namespace Memorabilia.Application.Validators.Project;

public class ProjectBaseballValidator : AbstractValidator<Domain.Entities.ProjectBaseball>
{
	public ProjectBaseballValidator(int projectTypeId)
	{
		var projectType = Domain.Constants.ProjectType.Find(projectTypeId);

		if (projectType != Domain.Constants.ProjectType.BaseballType)
			return;

        RuleFor(x => x.BaseballTypeId)
            .GreaterThan(0)
            .WithName("BaseballTypeId")
            .WithMessage("Baseball Type is required.");

        RuleFor(x => x.Year)
           .GreaterThanOrEqualTo(1930)
           .LessThanOrEqualTo(DateTime.UtcNow.Year)
           .When(x => x.Year.HasValue)
           .WithName("Baseball Type Year")
           .WithMessage($"Baseball Type Year must be between 1930 and {DateTime.UtcNow.Year}.");
    }
}
