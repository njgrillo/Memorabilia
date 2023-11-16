namespace Memorabilia.Application.Features.Admin.Teams;

[AuthorizeByRole(Enum.Role.Admin)]
public class SaveTeamConference
{
    public class Handler(ITeamRepository teamRepository) 
        : CommandHandler<Command>
    {
        protected override async Task Handle(Command command)
        {
            Entity.Team team = await teamRepository.Get(command.TeamId);

            if (command.DeletedItemIds.Length != 0)
                team.RemoveConferences(command.DeletedItemIds);

            foreach (var teamConference in command.Items.Where(item => !item.IsDeleted))
            {
                team.SetConference(teamConference.Id, 
                                   teamConference.ConferenceId, 
                                   teamConference.BeginYear, 
                                   teamConference.EndYear);
            }                

            await teamRepository.Update(team);
        }
    }

    public class Command(int teamId, IEnumerable<TeamConferenceEditModel> items) 
        : DomainCommand, ICommand
    {
        public int[] DeletedItemIds 
            => Items.Where(item => item.IsDeleted)
                    .Select(item => item.Id)
                    .ToArray();

        public TeamConferenceEditModel[] Items { get; } 
            = items.ToArray();

        public int TeamId { get; set; } 
            = teamId;
    }
}
