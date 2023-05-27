namespace Memorabilia.Application.Validators.Project;

public class ProjectCardValidator : AbstractValidator<Domain.Entities.ProjectCard>
{
    public ProjectCardValidator(int projectTypeId)
    {
        var projectType = Domain.Constants.ProjectType.Find(projectTypeId);

        if (projectType != Domain.Constants.ProjectType.Card)
            return;

        RuleFor(x => x.BrandId)
            .GreaterThan(0)
            .WithName("BrandId")
            .WithMessage("Brand is required.");

        RuleFor(x => x.Year)
           .GreaterThanOrEqualTo(1900)
           .LessThanOrEqualTo(DateTime.UtcNow.Year)
           .When(x => x.Year.HasValue)
           .WithName("Card Year")
           .WithMessage($"Card Year must be between 1900 and {DateTime.UtcNow.Year}.");
    }
}
