namespace Memorabilia.Application.Features.Admin.Teams;

[AuthorizeByRole(Enum.Role.Admin)]
public class SaveTeamLeague
{
    public class Handler(ITeamRepository teamRepository) 
        : CommandHandler<Command>
    {
        protected override async Task Handle(Command command)
        {
            Entity.Team team = await teamRepository.Get(command.TeamId);

            if (command.DeletedItemIds.HasAny())
                team.RemoveDivisions(command.DeletedItemIds);

            foreach (var leagueTeam in command.Items.Where(item => !item.IsDeleted))
            {
                team.SetLeague(leagueTeam.Id, 
                               leagueTeam.LeagueId, 
                               leagueTeam.BeginYear, 
                               leagueTeam.EndYear);
            }                

            await teamRepository.Update(team);
        }
    }

    public class Command(int teamId, IEnumerable<TeamLeagueEditModel> items) :
        DomainCommand, ICommand
    {
        public int[] DeletedItemIds 
            => Items.Where(item => item.IsDeleted)
                    .Select(item => item.Id)
                    .ToArray();

        public TeamLeagueEditModel[] Items { get; } 
            = items.ToArray();

        public int TeamId { get; set; } 
            = teamId;
    }
}
