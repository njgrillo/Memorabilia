namespace Memorabilia.Application.Features.Tools.Profile.Baseball;

public class BaseballProfileModel : SportProfileModel
{
    public BaseballProfileModel() { }

    public BaseballProfileModel(Entity.Person person) : base(person) { }

    public override string ChampionshipSummaryDisplayText 
        => $"{Championships?.Count() ?? 0}x World Series Champion";

    public override string Debut 
        => Service?.DebutDate.HasValue ?? false
        ? $"MLB Debut {Service.DebutDate.Value:MM/dd/yyyy}"
        : string.Empty; 

    public override string LastAppearance 
        => Service?.LastAppearanceDate.HasValue ?? false
        ? $"Last MLB Appearance {Service.LastAppearanceDate.Value:MM/dd/yyyy}"
        : string.Empty;    

    public override string NameHeader 
    { 
        get
        {
            var header = base.NameHeader;
            var hof = HallOfFames.SingleOrDefault(hof => hof.SportLeagueLevel == Constant.SportLeagueLevel.MajorLeagueBaseball);

            if (hof == null)
                return header;

            return $"{header} | HOF {hof.InductionYear}";
        }
    }  
}
