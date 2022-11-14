using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.LeaguePresidents;

public class LeaguePresidentViewModel : IWithName, IWithValue<int>
{
    private readonly LeaguePresident _president;

    public LeaguePresidentViewModel() { }

    public LeaguePresidentViewModel(LeaguePresident president)
    {
        _president = president;
    }

    public int? BeginYear => _president.BeginYear;

    public int? EndYear => _president.EndYear;

    public int Id => _president.Id;

    public int LeagueId => _president.LeagueId;

    public string LeagueName => Domain.Constants.League.Find(LeagueId)?.Name;

    string IWithName.Name => Person.DisplayName;

    public Person Person => _president.Person;

    public int SportLeagueLevelId => _president.SportLeagueLevelId;

    public string SportLeagueLevelName => _president.SportLeagueLevelName;

    int IWithValue<int>.Value => Id;
}
