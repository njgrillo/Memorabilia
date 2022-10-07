﻿namespace Memorabilia.Application.Features.Admin.Teams;

public class SaveTeamChampionship
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
                team.RemoveChampionships(command.DeletedItemIds);

            foreach (var teamChampionship in command.Items.Where(item => !item.IsDeleted))
            {
                team.SetChampionship(teamChampionship.Id, teamChampionship.ChampionshipTypeId, teamChampionship.Year);
            }

            await _teamRepository.Update(team);
        }
    }

    public class Command : DomainCommand, ICommand
    {
        public Command(int teamId, IEnumerable<SaveTeamChampionshipViewModel> items)
        {
            TeamId = teamId;
            Items = items.ToArray();
        }

        public int[] DeletedItemIds => Items.Where(item => item.IsDeleted).Select(item => item.Id).ToArray();

        public SaveTeamChampionshipViewModel[] Items { get; }

        public int TeamId { get; set; }
    }
}
