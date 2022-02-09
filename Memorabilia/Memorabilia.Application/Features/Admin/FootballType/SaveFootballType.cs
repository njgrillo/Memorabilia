using Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.FootballType
{
    public class SaveFootballType
    {
        public class Handler : CommandHandler<Command>
        {
            private readonly IFootballTypeRepository _footballTypeRepository;

            public Handler(IFootballTypeRepository footballTypeRepository)
            {
                _footballTypeRepository = footballTypeRepository;
            }

            protected override async Task Handle(Command command)
            {
                Domain.Entities.FootballType footballType;

                if (command.IsNew)
                {
                    footballType = new Domain.Entities.FootballType(command.Name, command.Abbreviation);
                    await _footballTypeRepository.Add(footballType).ConfigureAwait(false);

                    return;
                }

                footballType = await _footballTypeRepository.Get(command.Id).ConfigureAwait(false);

                if (command.IsDeleted)
                {
                    await _footballTypeRepository.Delete(footballType).ConfigureAwait(false);

                    return;
                }

                footballType.Set(command.Name, command.Abbreviation);

                await _footballTypeRepository.Update(footballType).ConfigureAwait(false);
            }
        }

        public class Command : DomainEntityCommand
        {
            public Command(SaveDomainViewModel viewModel) : base(viewModel)
            {
            }
        }
    }
}
