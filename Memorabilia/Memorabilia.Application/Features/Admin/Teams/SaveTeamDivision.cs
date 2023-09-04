namespace Memorabilia.Application.Features.Admin.Teams;

[AuthorizeByRole(Enum.PermissionType.Admin)]
public class SaveTeamDivision
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

            foreach (var teamDivision in command.Items.Where(item => item.IsNew))
            {
                team.SetDivision(teamDivision.Id, 
                                 teamDivision.Division.Id, 
                                 teamDivision.BeginYear, 
                                 teamDivision.EndYear);
            }                

            await _teamRepository.Update(team);
        }
    }

    public class Command : DomainCommand, ICommand
    {
        public Command(int teamId, IEnumerable<TeamDivisionEditModel> items)
        {
            TeamId = teamId;
            Items = items.ToArray();
        }

        public int[] DeletedItemIds 
            => Items.Where(item => item.IsDeleted)
                    .Select(item => item.Id)
                    .ToArray();

        public TeamDivisionEditModel[] Items { get; }

        public int TeamId { get; set; }
    }
}
