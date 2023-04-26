namespace Memorabilia.Application.Validators.Admin.People;

public class TeamValidator : AbstractValidator<SavePersonTeam.Command>
{
    public TeamValidator()
    {
        RuleFor(x => x.Teams.Where(team => !team.IsDeleted).ToArray())
            .Must(x => !HasInvalidYear(x))
            .WithMessage("End Year cannot be before Begin Year.");
    }

    private static bool HasInvalidYear(SavePersonTeamViewModel[] teams)
    {
        bool hasInvalidYear = false;

        foreach (SavePersonTeamViewModel team in teams)
        {
            if (!team.BeginYear.HasValue || !team.EndYear.HasValue)
                continue;

            hasInvalidYear = (team.EndYear ?? 0) < (team.BeginYear ?? 0);

            if (hasInvalidYear)
                break;
        }

        return hasInvalidYear;
    }
}
