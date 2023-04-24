namespace Memorabilia.Blazor.Pages.Tools.NewProfileStuff;

public partial class AccomplishmentSummaryProfile : PersonProfile
{
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
        => $"{Championships?.Length ?? 0}x {ChampionType.Find(Sport)?.ToString()} Champion";

    private AwardProfileViewModel[] DistinctAwards = Array.Empty<AwardProfileViewModel>();

    private LeaderProfileViewModel[] DistinctLeaders = Array.Empty<LeaderProfileViewModel>();

    private LeaderProfileViewModel[] Leaders = Array.Empty<LeaderProfileViewModel>();

    protected override void OnInitialized()
    {
        Accomplishments = Person.Accomplishments
                                .Filter(Sport, OccupationType)
                                .Select(accomplishment => new AccomplishmentProfileViewModel(accomplishment))
                                .DistinctBy(accomplishment => accomplishment.AccomplishmentTypeId)
                                .ToArray();

        Domain.Entities.PersonTeam[] teams
            = Person.Teams
                    .Filter(Sport, OccupationType)
                    .Where(team => Sport == null || Sport.Id == team.Team.Franchise.SportLeagueLevel.SportId)
                    .ToArray();

        AllStars = Person.AllStars
                         .Filter(Sport, OccupationType)
                         .Select(allStar => new AllStarProfileViewModel(allStar, teams.FirstOrDefault(team => team.BeginYear <= allStar.Year && team.EndYear >= allStar.Year)))
                         .OrderBy(allStar => allStar.Year)
                         .ToArray();

        Awards = Person.Awards
                       .Filter(Sport, OccupationType)
                       .Select(award => new AwardProfileViewModel(award))
                       .OrderBy(award => award.Year)
                       .ThenBy(award => award.AwardTypeName)
                       .ToArray();

        DistinctAwards = Awards.DistinctBy(award => award.AwardTypeId)
                               .ToArray();

        Championships = Person.Teams
                              .Championships(Sport, OccupationType)
                              .Select(championship => new ChampionshipProfileViewModel(championship))
                              .ToArray();

        Leaders = Person.Leaders
                        .Filter(Sport, OccupationType)
                        .Select(leader => new LeaderProfileViewModel(leader))
                        .OrderBy(leader => leader.Year)
                        .ThenBy(leader => leader.LeaderTypeName)                        
                        .ToArray();

        DistinctLeaders = Leaders.DistinctBy(leader => leader.LeaderTypeId)
                                 .ToArray();
    }
}
