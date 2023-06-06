namespace Memorabilia.Application.Validators.Project;

public class ProjectHelmetValidator : AbstractValidator<Domain.Entities.ProjectHelmet>
{
    public ProjectHelmetValidator(int projectTypeId)
    {
        var projectType = Constant.ProjectType.Find(projectTypeId);

        if (projectType != Constant.ProjectType.HelmetType)
            return;

        RuleFor(x => x.HelmetTypeId)
            .GreaterThan(0)
            .WithName("HelmetTypeId")
            .WithMessage("Helmet Type is required.");
    }
}
