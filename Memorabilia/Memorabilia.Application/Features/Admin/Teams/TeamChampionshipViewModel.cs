using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Teams;

public class TeamChampionshipViewModel
{
    private readonly Champion _champion;

    public TeamChampionshipViewModel() { }

    public TeamChampionshipViewModel(Champion champion)
    {
        _champion = champion;
    }

    public int ChampionTypeId => _champion.ChampionTypeId;        

    public int Id => _champion.Id;

    public int SportLeagueLevelId => _champion.Team.Franchise.SportLeagueLevelId;

    public int TeamId => _champion.TeamId;

    public int Year => _champion.Year;
}
