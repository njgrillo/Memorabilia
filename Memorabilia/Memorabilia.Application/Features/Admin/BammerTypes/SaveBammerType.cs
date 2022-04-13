using Framework.Handler;
using Memorabilia.Domain.Entities;
using Memorabilia.Repository.Interfaces;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.BammerTypes
{
    public class SaveBammerType
    {
        public class Handler : CommandHandler<Command>
        {
            private readonly IBammerTypeRepository _bammerTypeRepository;

            public Handler(IBammerTypeRepository bammerTypeRepository)
            {
                _bammerTypeRepository = bammerTypeRepository;
            }

            protected override async Task Handle(Command command)
            {
                BammerType bammerType;

                if (command.IsNew)
                {
                    bammerType = new BammerType(command.Name, command.Abbreviation);
                    await _bammerTypeRepository.Add(bammerType).ConfigureAwait(false);

                    return;
                }

                bammerType = await _bammerTypeRepository.Get(command.Id).ConfigureAwait(false);

                if (command.IsDeleted)
                {
                    await _bammerTypeRepository.Delete(bammerType).ConfigureAwait(false);

                    return;
                }

                bammerType.Set(command.Name, command.Abbreviation);

                await _bammerTypeRepository.Update(bammerType).ConfigureAwait(false);
            }
        }

        public class Command : DomainEntityCommand
        {
            public Command(SaveDomainViewModel viewModel) : base(viewModel) { }
        }
    }
}
