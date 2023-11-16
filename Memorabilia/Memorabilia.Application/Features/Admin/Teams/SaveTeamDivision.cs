namespace Memorabilia.Application.Features.Admin.Teams;

[AuthorizeByRole(Enum.Role.Admin)]
public class SaveTeamDivision
{
    public class Handler(ITeamRepository teamRepository) 
        : CommandHandler<Command>
    {
        protected override async Task Handle(Command command)
        {
            Entity.Team team = await teamRepository.Get(command.TeamId);

            if (command.DeletedItemIds.Length != 0)
                team.RemoveDivisions(command.DeletedItemIds);

            foreach (var teamDivision in command.Items.Where(item => item.IsNew))
            {
                team.SetDivision(teamDivision.Id, 
                                 teamDivision.Division.Id, 
                                 teamDivision.BeginYear, 
                                 teamDivision.EndYear);
            }                

            await teamRepository.Update(team);
        }
    }

    public class Command(int teamId, IEnumerable<TeamDivisionEditModel> items) 
        : DomainCommand, ICommand
    {
        public int[] DeletedItemIds 
            => Items.Where(item => item.IsDeleted)
                    .Select(item => item.Id)
                    .ToArray();

        public TeamDivisionEditModel[] Items { get; } 
            = items.ToArray();

        public int TeamId { get; set; } 
            = teamId;
    }
}
