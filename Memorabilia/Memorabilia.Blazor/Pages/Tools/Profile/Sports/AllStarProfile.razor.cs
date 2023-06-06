namespace Memorabilia.Blazor.Pages.Tools.Profile.Sports;

public partial class AllStarProfile : SportProfile
{
    private AllStarProfileModel[] AllStars = Array.Empty<AllStarProfileModel>();

    private string HeaderText
        => Sport == Sport.Football
        ? "Pro Bowl"
        : "All Star Game";

    protected override void OnParametersSet()
    {
        if (OccupationType != Domain.Constants.Occupation.Athlete)
            return;

        Domain.Entities.PersonTeam[] teams 
            = Person.Teams
                    .Where(team => Sport == null || Sport.Id == team.Team.Franchise.SportLeagueLevel.SportId)
                    .ToArray();

        AllStars = Person.AllStars
                         .Filter(Sport, OccupationType)
                         .Select(allStar => new AllStarProfileModel(allStar, teams.FirstOrDefault(team => team.BeginYear <= allStar.Year && team.EndYear >= allStar.Year)))
                         .OrderBy(allStar => allStar.Year)
                         .ToArray();
    }
}
