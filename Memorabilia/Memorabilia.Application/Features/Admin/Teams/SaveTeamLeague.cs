namespace Memorabilia.Application.Features.Admin.Teams;

[AuthorizeByRole(Enum.Role.Admin)]
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
            Entity.Team team = await _teamRepository.Get(command.TeamId);

            if (command.DeletedItemIds.Any())
                team.RemoveDivisions(command.DeletedItemIds);

            foreach (var leagueTeam in command.Items.Where(item => !item.IsDeleted))
            {
                team.SetLeague(leagueTeam.Id, 
                               leagueTeam.LeagueId, 
                               leagueTeam.BeginYear, 
                               leagueTeam.EndYear);
            }                

            await _teamRepository.Update(team);
        }
    }

    public class Command : DomainCommand, ICommand
    {
        public Command(int teamId, IEnumerable<TeamLeagueEditModel> items)
        {
            TeamId = teamId;
            Items = items.ToArray();
        }

        public int[] DeletedItemIds 
            => Items.Where(item => item.IsDeleted)
                    .Select(item => item.Id)
                    .ToArray();

        public TeamLeagueEditModel[] Items { get; }

        public int TeamId { get; set; }
    }
}
