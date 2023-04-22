namespace Memorabilia.Blazor.Pages.Tools.NewProfileStuff.Sports;

public partial class AllStarProfile 
{
    [Parameter]
    public Domain.Entities.Person Person { get; set; }

    [Parameter]
    public Sport Sport { get; set; }

    private AllStarProfileViewModel[] AllStars = Array.Empty<AllStarProfileViewModel>();

    protected override void OnParametersSet()
    {
        Domain.Entities.PersonTeam[] teams 
            = Person.Teams
                    .Where(team => Sport == null || Sport.Id == team.Team.Franchise.SportLeagueLevel.SportId)
                    .ToArray();

        AllStars = Person.AllStars
                         .Filter(Sport)
                         .Select(allStar => new AllStarProfileViewModel(allStar, teams.FirstOrDefault(team => team.BeginYear <= allStar.Year && team.EndYear >= allStar.Year)))
                         .OrderBy(allStar => allStar.Year)
                         .ToArray();
    }
}
