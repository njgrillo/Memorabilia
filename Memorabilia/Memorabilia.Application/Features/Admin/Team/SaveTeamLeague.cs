using Framework.Domain.Command;
using Framework.Handler;
using Memorabilia.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.Team
{
    public class SaveTeamLeague
    {
        public class Handler : CommandHandler<Command>
        {
            private readonly ITeamRepository _teamRepository;

            public Handler(ITeamRepository teamRepository)
            {
                _teamRepository = teamRepository;
            }

            protected override async Task Handle(Command command)
            {
                var team = await _teamRepository.Get(command.TeamId).ConfigureAwait(false);

                if (command.DeletedItemIds.Any())
                    team.RemoveDivisions(command.DeletedItemIds);

                foreach (var leagueTeam in command.Items.Where(item => !item.IsDeleted))
                {
                    team.SetLeague(leagueTeam.Id, leagueTeam.LeagueId, leagueTeam.BeginYear, leagueTeam.EndYear);
                }                

                await _teamRepository.Update(team).ConfigureAwait(false);
            }
        }

        public class Command : DomainCommand, ICommand
        {
            public Command(int teamId, IEnumerable<SaveTeamLeagueViewModel> items)
            {
                TeamId = teamId;
                Items = items.ToArray();
            }

            public int[] DeletedItemIds => Items.Where(item => item.IsDeleted).Select(item => item.Id).ToArray();

            public SaveTeamLeagueViewModel[] Items { get; }

            public int TeamId { get; set; }
        }
    }
}
