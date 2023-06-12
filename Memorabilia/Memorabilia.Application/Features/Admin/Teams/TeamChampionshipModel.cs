namespace Memorabilia.Application.Features.Admin.Teams;

public class TeamChampionshipModel
{
    private readonly Entity.Champion _champion;

    public TeamChampionshipModel() { }

    public TeamChampionshipModel(Entity.Champion champion)
    {
        _champion = champion;
    }

    public int ChampionTypeId 
        => _champion.ChampionTypeId;        

    public int Id 
        => _champion.Id;

    public int SportLeagueLevelId 
        => _champion.Team.Franchise.SportLeagueLevelId;

    public int TeamId 
        => _champion.TeamId;

    public int Year 
        => _champion.Year;
}
