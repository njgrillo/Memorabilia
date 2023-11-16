namespace Memorabilia.Application.Features.Admin.Teams;

public class TeamModel : IWithName, IWithValue<int>
{
    private readonly Entity.Team _team;

    public TeamModel() { }

    public TeamModel(Entity.Team team)
    {
        _team = team;
    }

    public string Abbreviation 
        => _team.Abbreviation;

    public int? BeginYear 
        => _team.BeginYear;

    public string DisplayName 
        => _team != null 
            ? $"{Constant.AdminDomainItem.Franchises.Item}: {_team.Franchise.FullName}, {Constant.AdminDomainItem.Teams.Item}: {_team.Location} {_team.Name} ({_team.BeginYear} - {(_team.EndYear.HasValue ? _team.EndYear : "current")})"
            : string.Empty;

    public int? EndYear 
        => _team.EndYear;

    public int FranchiseId 
        => _team.FranchiseId;

    public string FranchiseName 
        => Constant.Franchise.Find(FranchiseId).Name;

    public int Id 
        => _team.Id;

    public string Location 
        => _team.Location;

    public string Name 
        => _team.Name;

    public string NameWithYear 
        => _team != null
            ? $"{_team.Location} {_team.Name} ({_team.BeginYear} - {(_team.EndYear.HasValue ? _team.EndYear : "current")})"
            : string.Empty;

    public string Nickname 
        => _team.Nickname;

    public int SportId 
        => _team.Franchise.SportLeagueLevel.SportId;

    public Constant.SportLeagueLevel SportLeagueLevel 
        => Constant.SportLeagueLevel.Find(_team.Franchise.SportLeagueLevelId);

    int IWithValue<int>.Value 
        => Id;
}
