namespace Memorabilia.Application.Features.Admin.Teams;

public class SaveTeamConference
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
            var team = await _teamRepository.Get(command.TeamId);

            if (command.DeletedItemIds.Any())
                team.RemoveConferences(command.DeletedItemIds);

            foreach (var teamConference in command.Items.Where(item => !item.IsDeleted))
            {
                team.SetConference(teamConference.Id, teamConference.ConferenceId, teamConference.BeginYear, teamConference.EndYear);
            }                

            await _teamRepository.Update(team);
        }
    }

    public class Command : DomainCommand, ICommand
    {
        public Command(int teamId, IEnumerable<SaveTeamConferenceViewModel> items)
        {
            TeamId = teamId;
            Items = items.ToArray();
        }

        public int[] DeletedItemIds => Items.Where(item => item.IsDeleted).Select(item => item.Id).ToArray();

        public SaveTeamConferenceViewModel[] Items { get; }

        public int TeamId { get; set; }
    }
}
