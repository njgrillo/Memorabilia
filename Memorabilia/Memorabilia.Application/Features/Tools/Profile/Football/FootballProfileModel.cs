namespace Memorabilia.Application.Features.Tools.Profile.Football;

public class FootballProfileModel : SportProfileModel
{
    public FootballProfileModel() { }

    public FootballProfileModel(Entity.Person person) : base(person) { }
    
    public override string AllStarSummaryDisplayText 
        => $"{AllStars?.Count() ?? 0}x Pro Bowler";

    public override string ChampionshipSummaryDisplayText 
        => $"{Championships?.Count() ?? 0}x Super Bowl Champion";

    public override string Debut 
        => Service?.DebutDate.HasValue ?? false
        ? $"NFL Debut {Service.DebutDate.Value:MM/dd/yyyy}"
        : string.Empty;    

    public override string LastAppearance 
        => Service?.LastAppearanceDate.HasValue ?? false
        ? $"Last NFL Appearance {Service.LastAppearanceDate.Value:MM/dd/yyyy}"
        : string.Empty;

    public override string NameHeader
    {
        get
        {
            var header = base.NameHeader;
            var hof = HallOfFames.SingleOrDefault(hof => hof.SportLeagueLevel == Constant.SportLeagueLevel.NationalFootballLeague);

            if (hof == null)
                return header;

            return $"{header} | HOF {hof.InductionYear}";
        }
    }
}
