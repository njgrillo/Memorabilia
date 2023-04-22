namespace Memorabilia.Blazor.Pages.Tools.NewProfileStuff;

public partial class AccomplishmentSummaryProfile
{
    [Parameter]
    public Domain.Entities.Person Person { get; set; }

    [Parameter]
    public Sport Sport { get; set; }

    private AccomplishmentProfileViewModel[] Accomplishments = Array.Empty<AccomplishmentProfileViewModel>();

    private AllStarProfileViewModel[] AllStars = Array.Empty<AllStarProfileViewModel>();

    private string AllStarSummaryDisplayText 
        => Sport.HasAllStarGames(Sport)
        ? $"{AllStars?.Length ?? 0}x All Star"
        : Sport.HasProBowlGames(Sport)
            ? $"{AllStars?.Length ?? 0}x Pro Bowler"
            : string.Empty;

    private AwardProfileViewModel[] Awards = Array.Empty<AwardProfileViewModel>();

    private ChampionshipProfileViewModel[] Championships = Array.Empty<ChampionshipProfileViewModel>();

    private string ChampionshipSummaryDisplayText 
        => $"{Championships?.Length ?? 0}x {ChampionType.Find(Sport)?.Name} Champion";

    private LeaderProfileViewModel[] Leaders = Array.Empty<LeaderProfileViewModel>();

    protected override void OnInitialized()
    {
        Accomplishments = Person.Accomplishments
                                .Filter(Sport)
                                .Select(accomplishment => new AccomplishmentProfileViewModel(accomplishment))
                                .DistinctBy(accomplishment => accomplishment.AccomplishmentTypeId)
                                .ToArray();

        Domain.Entities.PersonTeam[] teams
            = Person.Teams
                    .Where(team => Sport == null || Sport.Id == team.Team.Franchise.SportLeagueLevel.SportId)
                    .ToArray();

        AllStars = Person.AllStars
                         .Filter(Sport)
                         .Select(allStar => new AllStarProfileViewModel(allStar, teams.FirstOrDefault(team => team.BeginYear <= allStar.Year && team.EndYear >= allStar.Year)))
                         .OrderBy(allStar => allStar.Year)
                         .ToArray();

        Awards = Person.Awards
                       .Filter(Sport)
                       .Select(award => new AwardProfileViewModel(award))
                       .DistinctBy(award => award.AwardTypeId)
                       .OrderBy(award => award.Year)
                       .ThenBy(award => award.AwardTypeName)
                       .ToArray();

        Championships = Person.Teams
                              .Championships(Sport)
                              .Select(championship => new ChampionshipProfileViewModel(championship))
                              .ToArray();

        Leaders = Person.Leaders
                        .Filter(Sport)
                        .Select(leader => new LeaderProfileViewModel(leader))
                        .DistinctBy(leader => leader.LeaderTypeId)
                        .OrderBy(leader => leader.Year)
                        .ThenBy(leader => leader.LeaderTypeName)                        
                        .ToArray();
    }
}
