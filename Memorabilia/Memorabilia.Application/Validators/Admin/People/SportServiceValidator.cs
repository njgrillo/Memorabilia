namespace Memorabilia.Application.Validators.Admin.People;

public class SportServiceValidator : AbstractValidator<SavePersonSportService.Command>
{
    public SportServiceValidator()
    {
        RuleFor(x => x.Colleges)
            .Must(x => !HasInvalidYear(x))
            .WithMessage("End Year cannot be before Begin Year.");

        RuleFor(x => x.DebutDate)
            .LessThanOrEqualTo(x => x.LastAppearanceDate)
            .When(x => x.DebutDate.HasValue && x.LastAppearanceDate.HasValue)
            .WithName("Debut Date")
            .WithMessage("Debut Date cannot be after Last Appearance Date.");

        RuleFor(x => x.FreeAgentSigningDate)
            .LessThanOrEqualTo(x => x.LastAppearanceDate)
            .When(x => x.FreeAgentSigningDate.HasValue && x.LastAppearanceDate.HasValue)
            .WithName("Free Agent Signing Date")
            .WithMessage("Free Agent Signing Date cannot be after Last Appearance Date.");

        RuleFor(x => x.FreeAgentSigningDate)
            .LessThanOrEqualTo(x => x.DebutDate)
            .When(x => x.FreeAgentSigningDate.HasValue && x.DebutDate.HasValue)
            .WithName("Free Agent Signing Date")
            .WithMessage("Free Agent Signing Date cannot be after Debut Date.");
    }

    private static bool HasInvalidYear(PersonCollegeEditModel[] colleges)
    {
        bool hasInvalidYear = false;

        foreach (PersonCollegeEditModel college in colleges)
        {
            if (!college.BeginYear.HasValue || !college.EndYear.HasValue)
                continue;

            hasInvalidYear = (college.EndYear ?? 0) < (college.BeginYear ?? 0);

            if (hasInvalidYear)
                break;
        }

        return hasInvalidYear;
    }
}
