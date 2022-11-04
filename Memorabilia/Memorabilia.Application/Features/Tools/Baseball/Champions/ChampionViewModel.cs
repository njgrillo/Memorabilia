using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Tools.Baseball.Champions;

public class ChampionViewModel
{
    private readonly Champion _champion;

    public ChampionViewModel(Champion champion)
    {
        _champion = champion;
    }

    public string Franchise => _champion.Team.Franchise.FullName;

    public int TeamId => _champion.TeamId;

    public string TeamImagePath => _champion.Team.ImagePath;

    public string TeamName => _champion.Team.ToString();

    //public string ProfileLink => $"/Tools/BaseballProfile/{PersonId}";

    public string Year => _champion.Year.ToString();
}
