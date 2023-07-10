namespace Memorabilia.MinimalAPI.Models.Admin.LeaguePresidents;

public class LeaguePresidentApiModel
{
	private readonly Entity.LeaguePresident _leaguePresident;

	public LeaguePresidentApiModel(Entity.LeaguePresident leaguePresident)
	{
		_leaguePresident = leaguePresident;
	}

    public int? BeginYear
        => _leaguePresident.BeginYear;

    public int? EndYear
        => _leaguePresident.EndYear;

    public string League
        => Constant.League.Find(_leaguePresident.LeagueId).Name;

    public string Person
        => _leaguePresident.Person.ProfileName;

    public string Sport
        => Constant.SportLeagueLevel.Find(_leaguePresident.SportLeagueLevelId).Sport.Name;

    public string SportLeagueLevel
        => _leaguePresident.SportLeagueLevelName;
}
