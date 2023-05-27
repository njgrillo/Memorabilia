namespace Memorabilia.Application.Validators.Project;

public class ProjectValidator : AbstractValidator<SaveProject.Command>
{
    public ProjectValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .NotNull()
            .WithName("Name")
            .WithMessage("Name is required.");

        RuleFor(x => x.Name)
            .MaximumLength(1000)
            .WithName("Name")
            .WithMessage("Name must be 1000 characters or less.");

        RuleFor(x => x.ProjectTypeId)
            .GreaterThan(0)
            .WithName("ProjectTypeId")
            .WithMessage("ProjectTypeId is required.");

        RuleForEach(x => x.People)
            .SetValidator(new ProjectPersonValidator());

        RuleFor(x => x.Baseball)
            .SetValidator(x => new ProjectBaseballValidator(x.ProjectTypeId));

        RuleFor(x => x.Card)
            .SetValidator(x => new ProjectCardValidator(x.ProjectTypeId));

        RuleFor(x => x.HallOfFame)
            .SetValidator(x => new ProjectHallOfFameValidator(x.ProjectTypeId));

        RuleFor(x => x.Helmet)
            .SetValidator(x => new ProjectHelmetValidator(x.ProjectTypeId));

        RuleFor(x => x.Item)
            .SetValidator(x => new ProjectItemValidator(x.ProjectTypeId));

        RuleFor(x => x.Team)
            .SetValidator(x => new ProjectTeamValidator(x.ProjectTypeId));

        RuleFor(x => x.WorldSeries)
            .SetValidator(x => new ProjectWorldSeriesValidator(x.ProjectTypeId));
    }
}
