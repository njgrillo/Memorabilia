using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.LeaderTypes;

public class SaveLeaderType
{
    public class Handler : CommandHandler<Command>
    {
        private readonly IDomainRepository<LeaderType> _leaderTypeRepository;

        public Handler(IDomainRepository<LeaderType> leaderTypeRepository)
        {
            _leaderTypeRepository = leaderTypeRepository;
        }

        protected override async Task Handle(Command command)
        {
            LeaderType leaderType;

            if (command.IsNew)
            {
                leaderType = new LeaderType(command.Name, command.Abbreviation);

                await _leaderTypeRepository.Add(leaderType);

                return;
            }

            leaderType = await _leaderTypeRepository.Get(command.Id);

            if (command.IsDeleted)
            {
                await _leaderTypeRepository.Delete(leaderType);

                return;
            }

            leaderType.Set(command.Name, command.Abbreviation);

            await _leaderTypeRepository.Update(leaderType);
        }
    }

    public class Command : DomainEntityCommand
    {
        public Command(SaveDomainViewModel viewModel) : base(viewModel) { }
    }
}
