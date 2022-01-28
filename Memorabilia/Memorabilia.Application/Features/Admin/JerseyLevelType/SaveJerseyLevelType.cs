using Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.JerseyLevelType
{
    public class SaveJerseyLevelType
    {
        public class Handler : CommandHandler<Command>
        {
            private readonly IJerseyLevelTypeRepository _jerseyLevelTypeRepository;

            public Handler(IJerseyLevelTypeRepository jerseyLevelTypeRepository)
            {
                _jerseyLevelTypeRepository = jerseyLevelTypeRepository;
            }

            protected override async Task Handle(Command command)
            {
                Domain.Entities.JerseyLevelType jerseyLevelType;

                if (command.IsNew)
                {
                    jerseyLevelType = new Domain.Entities.JerseyLevelType(command.Name, command.Abbreviation);
                    await _jerseyLevelTypeRepository.Add(jerseyLevelType).ConfigureAwait(false);

                    return;
                }

                jerseyLevelType = await _jerseyLevelTypeRepository.Get(command.Id).ConfigureAwait(false);

                if (command.IsDeleted)
                {
                    await _jerseyLevelTypeRepository.Delete(jerseyLevelType).ConfigureAwait(false);

                    return;
                }

                jerseyLevelType.Set(command.Name, command.Abbreviation);

                await _jerseyLevelTypeRepository.Update(jerseyLevelType).ConfigureAwait(false);
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
