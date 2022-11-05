using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Tools.Baseball.Players;

public class PlayersViewModel
{
    public PlayersViewModel() { }

    public PlayersViewModel(IEnumerable<PersonTeam> players)
    {
        Players = players.Select(player => new PlayerViewModel(player))
                         .OrderByDescending(player => player.BeginYear)
                         .ThenBy(player => player.PersonName);
    }    

    public int FranchiseId { get; set; }

    public string FranchiseName => Domain.Constants.Franchise.Find(FranchiseId)?.Name;

    public IEnumerable<PlayerViewModel> Players { get; set; } = Enumerable.Empty<PlayerViewModel>();

    public string ResultsTitle => $"{FranchiseName} Players";

    public int SportLeagueLevelId => Domain.Constants.SportLeagueLevel.MajorLeagueBaseball.Id;
}
