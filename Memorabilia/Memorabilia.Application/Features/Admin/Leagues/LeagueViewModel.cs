using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Leagues;

public class LeagueViewModel
{
    private readonly League _league;

    public LeagueViewModel() { }

    public LeagueViewModel(League league)
    {
        _league = league;
    }

    public string Abbreviation => _league.Abbreviation;

    public int Id => _league.Id;

    public string Name => _league.Name;

    public int SportLeagueLevelId => _league.SportLeagueLevelId;

    public string SportLeagueLevelName => Constant.SportLeagueLevel.Find(SportLeagueLevelId)?.Name;
}
