namespace Memorabilia.Application.Features.Admin.Teams;

[AuthorizeByRole(Enum.Role.Admin)]
public class SaveTeamChampionship
{
    public class Handler(ITeamRepository teamRepository) 
        : CommandHandler<Command>
    {
        protected override async Task Handle(Command command)
        {
            Entity.Team team = await teamRepository.Get(command.TeamId);

            if (command.DeletedItemIds.HasAny())
                team.RemoveChampionships(command.DeletedItemIds);

            foreach (var teamChampionship in command.Items.Where(item => !item.IsDeleted))
            {
                team.SetChampionship(teamChampionship.Id, 
                                     teamChampionship.ChampionshipTypeId, 
                                     teamChampionship.Year);
            }

            await teamRepository.Update(team);
        }
    }

    public class Command(int teamId, IEnumerable<TeamChampionshipEditModel> items) 
        : DomainCommand, ICommand
    {
        public int[] DeletedItemIds 
            => Items.Where(item => item.IsDeleted)
                    .Select(item => item.Id)
                    .ToArray();

        public TeamChampionshipEditModel[] Items { get; } 
            = items.ToArray();

        public int TeamId { get; set; } 
            = teamId;
    }
}
