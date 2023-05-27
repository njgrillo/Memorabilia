namespace Memorabilia.Application.Validators.Project;

public class ProjectItemValidator : AbstractValidator<Domain.Entities.ProjectItem>
{
    public ProjectItemValidator(int projectTypeId)
    {
        var projectType = Domain.Constants.ProjectType.Find(projectTypeId);

        if (projectType != Domain.Constants.ProjectType.ItemType)
            return;

        RuleFor(x => x.ItemTypeId)
            .GreaterThan(0)
            .WithName("ItemTypeId")
            .WithMessage("Item Type is required.");
    }
}
