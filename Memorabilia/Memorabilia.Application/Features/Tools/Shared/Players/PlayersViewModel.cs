using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Tools.Shared.Players;

public class PlayersViewModel
{
    public PlayersViewModel() { }

    public PlayersViewModel(IEnumerable<PersonTeam> players, Domain.Constants.Sport sport)
    {
        Players = players.Select(player => new PlayerViewModel(player, sport))
                         .OrderByDescending(player => player.BeginYear)
                         .ThenBy(player => player.PersonName);
    }    

    public Domain.Constants.Franchise Franchise { get; set; }

    public string FranchiseName => Franchise?.Name;

    public IEnumerable<PlayerViewModel> Players { get; set; } = Enumerable.Empty<PlayerViewModel>();

    public string ResultsTitle => $"{FranchiseName} Players";
}
