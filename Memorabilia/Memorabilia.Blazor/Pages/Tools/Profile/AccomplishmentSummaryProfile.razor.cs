namespace Memorabilia.Blazor.Pages.Tools.Profile;

public partial class AccomplishmentSummaryProfile : PersonProfile
{
    [Parameter]
    public Sport Sport { get; set; }

    private AccomplishmentProfileModel[] Accomplishments 
        = [];

    private AllStarProfileModel[] AllStars 
        = [];

    private string AllStarSummaryDisplayText 
        => Sport.HasAllStarGames(Sport)
            ? $"{AllStars?.Length ?? 0}x All Star"
            : Sport.HasProBowlGames(Sport)
                ? $"{AllStars?.Length ?? 0}x Pro Bowler"
                : string.Empty;

    private AwardProfileModel[] Awards 
        = [];

    private ChampionshipProfileModel[] Championships 
        = [];

    private string ChampionshipSummaryDisplayText
        => Championships.HasAny()
            ? $"{(Championships.Length > 1 ? Championships.Length : Championships.First().Year)}x {ChampionType.Find(Sport)?.ToString()} Champion"
            : string.Empty;

    private AccomplishmentProfileModel[] DistinctAccomplishments
        = [];

    private AwardProfileModel[] DistinctAwards 
        = [];

    private LeaderProfileModel[] DistinctLeaders 
        = [];

    private LeaderProfileModel[] Leaders 
        = [];

    protected override void OnInitialized()
    {
        Accomplishments = Person.Accomplishments
                                .Filter(Sport, OccupationType)
                                .Select(accomplishment => new AccomplishmentProfileModel(accomplishment))
                                .ToArray();

        DistinctAccomplishments = Accomplishments.DistinctBy(accomplishment => accomplishment.AccomplishmentTypeId)
                                                 .ToArray();

        Entity.PersonTeam[] teams
            = Person.Teams
                    .Filter(Sport, OccupationType)
                    .Where(team => Sport == null || Sport.Id == team.Team.Franchise.SportLeagueLevel.SportId)
                    .ToArray();

        AllStars = Person.AllStars
                         .Filter(Sport, OccupationType)
                         .Select(allStar => new AllStarProfileModel(allStar, teams.FirstOrDefault(team => team.BeginYear <= allStar.Year && team.EndYear >= allStar.Year)))
                         .OrderBy(allStar => allStar.Year)
                         .ToArray();

        Awards = Person.Awards
                       .Filter(Sport, OccupationType)
                       .Select(award => new AwardProfileModel(award))
                       .OrderBy(award => award.Year)
                       .ThenBy(award => award.AwardTypeName)
                       .ToArray();

        DistinctAwards = Awards.DistinctBy(award => award.AwardTypeId)
                               .ToArray();

        Championships = Person.Teams
                              .Championships(Sport, OccupationType)
                              .Select(championship => new ChampionshipProfileModel(championship))
                              .ToArray();

        Leaders = Person.Leaders
                        .Filter(Sport, OccupationType)
                        .Select(leader => new LeaderProfileModel(leader))
                        .OrderBy(leader => leader.Year)
                        .ThenBy(leader => leader.LeaderTypeName)                        
                        .ToArray();

        DistinctLeaders = Leaders.DistinctBy(leader => leader.LeaderTypeId)
                                 .ToArray();
    }

    private string GetAccomplishmentDisplayText(AccomplishmentProfileModel accomplishment)
    {
        int count = Accomplishments.Where(x => x.AccomplishmentTypeId == accomplishment.AccomplishmentTypeId)
                                   .Count();

        return $"{(count > 1 ? $"{count}x" : accomplishment.Year)} {accomplishment}";
    }

    private string GetAwardDisplayText(AwardProfileModel award)
    {
        int count = Awards.Where(x => x.AwardTypeId == award.AwardTypeId)
                          .Count();

        return $"{(count > 1 ? $"{count}x" : award.Year)} {award}";
    }

    private string GetLeaderDisplayText(LeaderProfileModel leader)
    {
        int count = Leaders.Where(x => x.LeaderTypeId == leader.LeaderTypeId)
                           .Count();

        return $"{(count > 1 ? $"{count}x" : leader.Year)} {leader} Leader";
    }
}
