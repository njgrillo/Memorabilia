namespace Memorabilia.Application.Validators.Admin.People;

public class HallOfFameValidator : AbstractValidator<SavePersonHallOfFame.Command>
{
    public HallOfFameValidator()
    {
        string inductionYearMessage
            = $"Invalid Induction Year.  Induction Year must be after 1900 and on/before {DateTime.UtcNow.Year + 1}";

        RuleFor(x => x.HallOfFames)
            .Must(x => !HasInvalidYear(x))
            .WithMessage(inductionYearMessage);

        RuleFor(x => x.FranchiseHallOfFames)
            .Must(x => !HasInvalidYear(x))
            .WithMessage(inductionYearMessage);

        RuleFor(x => x.CollegeHallOfFames)
            .Must(x => !HasInvalidYear(x))
            .WithMessage(inductionYearMessage);

        RuleFor(x => x.InternationalHallOfFames)
            .Must(x => !HasInvalidYear(x))
            .WithMessage(inductionYearMessage);
    }

    private static bool HasInvalidYear(PersonHallOfFameEditModel[] hofs)
    {
        bool hasInvalidYear = false;

        foreach (PersonHallOfFameEditModel hof in hofs)
        {
            hasInvalidYear = hof.InductionYear.HasValue && 
                             (hof.InductionYear.Value > DateTime.UtcNow.Year + 1 || hof.InductionYear.Value < 1900);

            if (hasInvalidYear)
                break;
        }

        return hasInvalidYear;
    }

    private static bool HasInvalidYear(PersonFranchiseHallOfFameEditModel[] hofs)
    {
        bool hasInvalidYear = false;

        foreach (PersonFranchiseHallOfFameEditModel hof in hofs)
        {
            hasInvalidYear = hof.Year.HasValue && 
                             (hof.Year.Value > DateTime.UtcNow.Year + 1 || hof.Year.Value < 1900);

            if (hasInvalidYear)
                break;
        }

        return hasInvalidYear;
    }

    private static bool HasInvalidYear(PersonCollegeHallOfFameEditModel[] hofs)
    {
        bool hasInvalidYear = false;

        foreach (PersonCollegeHallOfFameEditModel hof in hofs)
        {
            hasInvalidYear = hof.Year.HasValue && 
                             (hof.Year.Value > DateTime.UtcNow.Year + 1 || hof.Year.Value < 1900);

            if (hasInvalidYear)
                break;
        }

        return hasInvalidYear;
    }

    private static bool HasInvalidYear(PersonInternationalHallOfFameEditModel[] hofs)
    {
        bool hasInvalidYear = false;

        foreach (PersonInternationalHallOfFameEditModel hof in hofs)
        {
            hasInvalidYear = hof.Year.HasValue && 
                             (hof.Year.Value > DateTime.UtcNow.Year + 1 || hof.Year.Value < 1900);

            if (hasInvalidYear)
                break;
        }

        return hasInvalidYear;
    }
}
