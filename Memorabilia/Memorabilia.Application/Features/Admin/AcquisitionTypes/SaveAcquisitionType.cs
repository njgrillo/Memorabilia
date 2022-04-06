using Framework.Handler;
using Memorabilia.Domain.Entities;
using Memorabilia.Repository.Interfaces;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.AcquisitionTypes
{
    public class SaveAcquisitionType
    {
        public class Handler : CommandHandler<Command>
        {
            private readonly IAcquisitionTypeRepository _acquisitionTypeRepository;

            public Handler(IAcquisitionTypeRepository acquisitionTypeRepository)
            {
                _acquisitionTypeRepository = acquisitionTypeRepository;
            }

            protected override async Task Handle(Command command)
            {
                AcquisitionType acquisitionType;

                if (command.IsNew)
                {
                    acquisitionType = new AcquisitionType(command.Name, command.Abbreviation);
                    await _acquisitionTypeRepository.Add(acquisitionType).ConfigureAwait(false);

                    return;
                }

                acquisitionType = await _acquisitionTypeRepository.Get(command.Id).ConfigureAwait(false);

                if (command.IsDeleted)
                {
                    await _acquisitionTypeRepository.Delete(acquisitionType).ConfigureAwait(false);

                    return;
                }

                acquisitionType.Set(command.Name, command.Abbreviation);

                await _acquisitionTypeRepository.Update(acquisitionType).ConfigureAwait(false);
            }
        }

        public class Command : DomainEntityCommand
        {
            public Command(SaveDomainViewModel viewModel) : base(viewModel) { }
        }
    }
}
