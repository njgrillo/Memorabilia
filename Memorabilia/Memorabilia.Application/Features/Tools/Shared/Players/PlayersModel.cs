using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Tools.Shared.Players;

public class PlayersModel
{
    public PlayersModel() { }

    public PlayersModel(IEnumerable<PersonTeam> players, Constant.Sport sport)
    {
        Players = players.Select(player => new PlayerModel(player, sport))
                         .OrderByDescending(player => player.BeginYear)
                         .ThenBy(player => player.PersonName);
    }    

    public Constant.Franchise Franchise { get; set; }

    public string FranchiseName => Franchise?.Name;

    public IEnumerable<PlayerModel> Players { get; set; } = Enumerable.Empty<PlayerModel>();

    public string ResultsTitle => $"{FranchiseName} Players";
}
