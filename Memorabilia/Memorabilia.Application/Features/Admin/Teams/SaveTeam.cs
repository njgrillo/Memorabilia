using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Teams;

public class SaveTeam
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
            Team team;

            if (command.IsNew)
            {
                team = new Team(command.FranchiseId, 
                                command.Name, 
                                command.Location, 
                                command.Nickname,
                                command.Abbreviation, 
                                command.BeginYear, 
                                command.EndYear, 
                                command.ImagePath);

                await _teamRepository.Add(team);

                command.Id = team.Id;

                return;
            }

            team = await _teamRepository.Get(command.Id);

            if (command.IsDeleted)
            {
                await _teamRepository.Delete(team);

                return;
            }

            team.Set(command.Name,
                     command.Location,
                     command.Nickname,
                     command.Abbreviation,
                     command.BeginYear,
                     command.EndYear,
                     command.ImagePath);

            await _teamRepository.Update(team);
        }
    }

    public class Command : DomainCommand, ICommand
    {
        private readonly SaveTeamViewModel _viewModel;

        public Command(SaveTeamViewModel viewModel)
        {
            _viewModel = viewModel;
            Id = _viewModel.Id;
        }

        public string Abbreviation => _viewModel.Abbreviation;

        public int? BeginYear => _viewModel.BeginYear;

        public int? EndYear => _viewModel.EndYear;

        public int FranchiseId => _viewModel.FranchiseId;

        public int Id { get; set; } 

        public string ImagePath => _viewModel.ImagePath;

        public bool IsDeleted => _viewModel.IsDeleted;

        public bool IsModified => _viewModel.IsModified;

        public bool IsNew => _viewModel.IsNew;

        public string Location => _viewModel.Location;

        public string Name => _viewModel.Name;

        public string Nickname => _viewModel.Nickname;
    }
}
