using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.AcquisitionTypes;

public class SaveAcquisitionType
{
    public class Handler : CommandHandler<Command>
    {
        private readonly IDomainRepository<AcquisitionType> _acquisitionTypeRepository;

        public Handler(IDomainRepository<AcquisitionType> acquisitionTypeRepository)
        {
            _acquisitionTypeRepository = acquisitionTypeRepository;
        }

        protected override async Task Handle(Command command)
        {
            AcquisitionType acquisitionType;

            if (command.IsNew)
            {
                acquisitionType = new AcquisitionType(command.Name, command.Abbreviation);

                await _acquisitionTypeRepository.Add(acquisitionType);

                return;
            }

            acquisitionType = await _acquisitionTypeRepository.Get(command.Id);

            if (command.IsDeleted)
            {
                await _acquisitionTypeRepository.Delete(acquisitionType);

                return;
            }

            acquisitionType.Set(command.Name, command.Abbreviation);

            await _acquisitionTypeRepository.Update(acquisitionType);
        }
    }

    public class Command : DomainEntityCommand
    {
        public Command(SaveDomainViewModel viewModel) : base(viewModel) { }
    }
}
