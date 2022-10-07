using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.TeamRoleTypes;

public class SaveTeamRoleType
{
    public class Handler : CommandHandler<Command>
    {
        private readonly IDomainRepository<TeamRoleType> _teamRoleTypeRepository;

        public Handler(IDomainRepository<TeamRoleType> teamRoleTypeRepository)
        {
            _teamRoleTypeRepository = teamRoleTypeRepository;
        }

        protected override async Task Handle(Command command)
        {
            TeamRoleType teamRoleType;

            if (command.IsNew)
            {
                teamRoleType = new TeamRoleType(command.Name, command.Abbreviation);

                await _teamRoleTypeRepository.Add(teamRoleType);

                return;
            }

            teamRoleType = await _teamRoleTypeRepository.Get(command.Id);

            if (command.IsDeleted)
            {
                await _teamRoleTypeRepository.Delete(teamRoleType);

                return;
            }

            teamRoleType.Set(command.Name, command.Abbreviation);

            await _teamRoleTypeRepository.Update(teamRoleType);
        }
    }

    public class Command : DomainEntityCommand
    {
        public Command(SaveDomainViewModel viewModel) : base(viewModel) { }
    }
}
