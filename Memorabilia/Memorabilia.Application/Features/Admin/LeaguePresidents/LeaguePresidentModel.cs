namespace Memorabilia.Application.Features.Admin.LeaguePresidents;

public class LeaguePresidentModel : IWithName, IWithValue<int>
{
    private readonly Entity.LeaguePresident _president;

    public LeaguePresidentModel() { }

    public LeaguePresidentModel(Entity.LeaguePresident president)
    {
        _president = president;
    }

    public int? BeginYear 
        => _president.BeginYear;

    public int? EndYear 
        => _president.EndYear;

    public int Id 
        => _president.Id;

    public int LeagueId 
        => _president.LeagueId;

    public string LeagueName 
        => Constant.League.Find(LeagueId)?.Name;

    string IWithName.Name 
        => Person.DisplayName;

    public Entity.Person Person 
        => _president.Person;

    public int SportLeagueLevelId 
        => _president.SportLeagueLevelId;

    public string SportLeagueLevelName 
        => _president.SportLeagueLevelName;

    int IWithValue<int>.Value 
        => Id;
}
