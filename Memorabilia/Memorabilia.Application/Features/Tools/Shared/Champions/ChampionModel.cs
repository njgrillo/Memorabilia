namespace Memorabilia.Application.Features.Tools.Shared.Champions;

public class ChampionModel : TeamSportToolModel
{
    private readonly Entity.Champion _champion;

    public ChampionModel(Entity.Champion champion, Constant.Sport sport)
    {
        _champion = champion;
        Sport = sport;
    }

    public string Franchise 
        => _champion.Team.Franchise.FullName;

    public override int TeamId 
        => _champion.TeamId;

    public override string TeamName 
        => _champion.Team.ToString();

    public string Year 
        => _champion.Year.ToString();
}
