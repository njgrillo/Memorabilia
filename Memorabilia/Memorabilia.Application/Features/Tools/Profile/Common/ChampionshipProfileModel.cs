namespace Memorabilia.Application.Features.Tools.Profile.Common;

public class ChampionshipProfileModel
{
    private readonly Entity.Champion _champion;

    public ChampionshipProfileModel(Entity.Champion champion)
    {
        _champion = champion;
    }

    public int ChampionshipTypeId 
        => _champion.ChampionTypeId;

    public string ChampionshipTypeName 
        => Constant.ChampionType.Find(ChampionshipTypeId)?.Name;

    public int TeamId 
        => _champion.TeamId;

    public string TeamName 
        => $"{_champion.Team?.Location} {_champion.Team?.Name}";        

    public int Year 
        => _champion.Year;
}
