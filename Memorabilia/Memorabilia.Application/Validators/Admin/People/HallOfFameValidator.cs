namespace Memorabilia.Application.Validators.Admin.People;

public class HallOfFameValidator : AbstractValidator<SavePersonHallOfFame.Command>
{
    public HallOfFameValidator()
    {
        var inductionYearMessage
            = $"Invalid Induction Year.  Induction Year must be after 1900 and on/before {DateTime.UtcNow.Year}";

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

    private bool HasInvalidYear(SavePersonHallOfFameViewModel[] hofs)
    {
        bool hasInvalidYear = false;

        foreach (SavePersonHallOfFameViewModel hof in hofs)
        {
            hasInvalidYear = hof.InductionYear.HasValue
                ? hof.InductionYear.Value > DateTime.UtcNow.Year || hof.InductionYear.Value < 1900
                : false;

            if (hasInvalidYear)
                break;
        }

        return hasInvalidYear;
    }

    private bool HasInvalidYear(SavePersonFranchiseHallOfFameViewModel[] hofs)
    {
        bool hasInvalidYear = false;

        foreach (SavePersonFranchiseHallOfFameViewModel hof in hofs)
        {
            hasInvalidYear = hof.Year.HasValue
                ? hof.Year.Value > DateTime.UtcNow.Year || hof.Year.Value < 1900
                : false;

            if (hasInvalidYear)
                break;
        }

        return hasInvalidYear;
    }

    private bool HasInvalidYear(SavePersonCollegeHallOfFameViewModel[] hofs)
    {
        bool hasInvalidYear = false;

        foreach (SavePersonCollegeHallOfFameViewModel hof in hofs)
        {
            hasInvalidYear = hof.Year.HasValue
                ? hof.Year.Value > DateTime.UtcNow.Year || hof.Year.Value < 1900
                : false;

            if (hasInvalidYear)
                break;
        }

        return hasInvalidYear;
    }

    private bool HasInvalidYear(SavePersonInternationalHallOfFameViewModel[] hofs)
    {
        bool hasInvalidYear = false;

        foreach (SavePersonInternationalHallOfFameViewModel hof in hofs)
        {
            hasInvalidYear = hof.Year.HasValue
                ? hof.Year.Value > DateTime.UtcNow.Year || hof.Year.Value < 1900
                : false;

            if (hasInvalidYear)
                break;
        }

        return hasInvalidYear;
    }
}
