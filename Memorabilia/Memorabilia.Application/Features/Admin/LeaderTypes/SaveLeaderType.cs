using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.LeaderTypes
{
    public class SaveLeaderType
    {
        public class Handler : CommandHandler<Command>
        {
            private readonly ILeaderTypeRepository _leaderTypeRepository;

            public Handler(ILeaderTypeRepository leaderTypeRepository)
            {
                _leaderTypeRepository = leaderTypeRepository;
            }

            protected override async Task Handle(Command command)
            {
                LeaderType leaderType;

                if (command.IsNew)
                {
                    leaderType = new LeaderType(command.Name, command.Abbreviation);
                    await _leaderTypeRepository.Add(leaderType).ConfigureAwait(false);

                    return;
                }

                leaderType = await _leaderTypeRepository.Get(command.Id).ConfigureAwait(false);

                if (command.IsDeleted)
                {
                    await _leaderTypeRepository.Delete(leaderType).ConfigureAwait(false);

                    return;
                }

                leaderType.Set(command.Name, command.Abbreviation);

                await _leaderTypeRepository.Update(leaderType).ConfigureAwait(false);
            }
        }

        public class Command : DomainEntityCommand
        {
            public Command(SaveDomainViewModel viewModel) : base(viewModel) { }
        }
    }
}
