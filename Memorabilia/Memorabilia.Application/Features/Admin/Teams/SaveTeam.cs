namespace Memorabilia.Application.Features.Admin.Teams;

[AuthorizeByRole(Enum.Role.Admin)]
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
            Entity.Team team;

            if (command.IsNew)
            {
                team = new Entity.Team(command.FranchiseId, 
                                       command.Name, 
                                       command.Location, 
                                       command.Nickname,
                                       command.Abbreviation, 
                                       command.BeginYear, 
                                       command.EndYear, 
                                       command.ImageFileName);

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
                     command.ImageFileName);

            await _teamRepository.Update(team);
        }
    }

    public class Command : DomainCommand, ICommand
    {
        private readonly TeamEditModel _editModel;

        public Command(TeamEditModel editModel)
        {
            _editModel = editModel;
            Id = _editModel.Id;
        }

        public string Abbreviation 
            => _editModel.Abbreviation;

        public int? BeginYear 
            => _editModel.BeginYear;

        public int? EndYear 
            => _editModel.EndYear;

        public int FranchiseId 
            => _editModel.Franchise.Id;

        public int Id { get; set; } 

        public string ImageFileName 
            => _editModel.ImageFileName;

        public bool IsDeleted 
            => _editModel.IsDeleted;

        public bool IsNew 
            => _editModel.IsNew;

        public string Location 
            => _editModel.Location;

        public string Name 
            => _editModel.Name;

        public string Nickname 
            => _editModel.Nickname;
    }
}
