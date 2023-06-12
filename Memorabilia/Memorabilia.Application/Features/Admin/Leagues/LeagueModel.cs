namespace Memorabilia.Application.Features.Admin.Leagues;

public class LeagueModel
{
    private readonly Entity.League _league;

    public LeagueModel() { }

    public LeagueModel(Entity.League league)
    {
        _league = league;
    }

    public string Abbreviation 
        => _league.Abbreviation;

    public int Id 
        => _league.Id;

    public string Name 
        => _league.Name;

    public int SportLeagueLevelId 
        => _league.SportLeagueLevelId;

    public string SportLeagueLevelName 
        => Constant.SportLeagueLevel.Find(SportLeagueLevelId)?.Name;
}
