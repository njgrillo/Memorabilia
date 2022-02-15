using Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.BatType
{
    public class SaveBatType
    {
        public class Handler : CommandHandler<Command>
        {
            private readonly IBatTypeRepository _batTypeRepository;

            public Handler(IBatTypeRepository batTypeRepository)
            {
                _batTypeRepository = batTypeRepository;
            }

            protected override async Task Handle(Command command)
            {
                Domain.Entities.BatType batType;

                if (command.IsNew)
                {
                    batType = new Domain.Entities.BatType(command.Name, command.Abbreviation);
                    await _batTypeRepository.Add(batType).ConfigureAwait(false);

                    return;
                }

                batType = await _batTypeRepository.Get(command.Id).ConfigureAwait(false);

                if (command.IsDeleted)
                {
                    await _batTypeRepository.Delete(batType).ConfigureAwait(false);

                    return;
                }

                batType.Set(command.Name, command.Abbreviation);

                await _batTypeRepository.Update(batType).ConfigureAwait(false);
            }
        }

        public class Command : DomainEntityCommand
        {
            public Command(SaveDomainViewModel viewModel) : base(viewModel) { }
        }
    }
}
