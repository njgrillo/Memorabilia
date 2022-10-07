using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.RecordTypes;

public class SaveRecordType
{
    public class Handler : CommandHandler<Command>
    {
        private readonly IDomainRepository<RecordType> _recordTypeRepository;

        public Handler(IDomainRepository<RecordType> recordTypeRepository)
        {
            _recordTypeRepository = recordTypeRepository;
        }

        protected override async Task Handle(Command command)
        {
            RecordType recordType;

            if (command.IsNew)
            {
                recordType = new RecordType(command.Name, command.Abbreviation);

                await _recordTypeRepository.Add(recordType);

                return;
            }

            recordType = await _recordTypeRepository.Get(command.Id);

            if (command.IsDeleted)
            {
                await _recordTypeRepository.Delete(recordType);

                return;
            }

            recordType.Set(command.Name, command.Abbreviation);

            await _recordTypeRepository.Update(recordType);
        }
    }

    public class Command : DomainEntityCommand
    {
        public Command(SaveDomainViewModel viewModel) : base(viewModel) { }
    }
}
