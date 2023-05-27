namespace Memorabilia.Application.Validators.Project;

public class ProjectHelmetValidator : AbstractValidator<Domain.Entities.ProjectHelmet>
{
    public ProjectHelmetValidator(int projectTypeId)
    {
        var projectType = Domain.Constants.ProjectType.Find(projectTypeId);

        if (projectType != Domain.Constants.ProjectType.HelmetType)
            return;

        RuleFor(x => x.HelmetTypeId)
            .GreaterThan(0)
            .WithName("HelmetTypeId")
            .WithMessage("Helmet Type is required.");
    }
}
