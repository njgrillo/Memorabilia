using Framework.Handler;
using Memorabilia.Domain.Entities;
using Memorabilia.Repository.Interfaces;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.TeamRoleTypes
{
    public class SaveTeamRoleType
    {
        public class Handler : CommandHandler<Command>
        {
            private readonly ITeamRoleTypeRepository _teamRoleTypeRepository;

            public Handler(ITeamRoleTypeRepository teamRoleTypeRepository)
            {
                _teamRoleTypeRepository = teamRoleTypeRepository;
            }

            protected override async Task Handle(Command command)
            {
                TeamRoleType teamRoleType;

                if (command.IsNew)
                {
                    teamRoleType = new TeamRoleType(command.Name, command.Abbreviation);
                    await _teamRoleTypeRepository.Add(teamRoleType).ConfigureAwait(false);

                    return;
                }

                teamRoleType = await _teamRoleTypeRepository.Get(command.Id).ConfigureAwait(false);

                if (command.IsDeleted)
                {
                    await _teamRoleTypeRepository.Delete(teamRoleType).ConfigureAwait(false);

                    return;
                }

                teamRoleType.Set(command.Name, command.Abbreviation);

                await _teamRoleTypeRepository.Update(teamRoleType).ConfigureAwait(false);
            }
        }

        public class Command : DomainEntityCommand
        {
            public Command(SaveDomainViewModel viewModel) : base(viewModel) { }
        }
    }
}
