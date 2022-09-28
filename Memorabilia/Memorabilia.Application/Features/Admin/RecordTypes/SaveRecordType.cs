using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.RecordTypes
{
    public class SaveRecordType
    {
        public class Handler : CommandHandler<Command>
        {
            private readonly IRecordTypeRepository _recordTypeRepository;

            public Handler(IRecordTypeRepository recordTypeRepository)
            {
                _recordTypeRepository = recordTypeRepository;
            }

            protected override async Task Handle(Command command)
            {
                RecordType recordType;

                if (command.IsNew)
                {
                    recordType = new RecordType(command.Name, command.Abbreviation);
                    await _recordTypeRepository.Add(recordType).ConfigureAwait(false);

                    return;
                }

                recordType = await _recordTypeRepository.Get(command.Id).ConfigureAwait(false);

                if (command.IsDeleted)
                {
                    await _recordTypeRepository.Delete(recordType).ConfigureAwait(false);

                    return;
                }

                recordType.Set(command.Name, command.Abbreviation);

                await _recordTypeRepository.Update(recordType).ConfigureAwait(false);
            }
        }

        public class Command : DomainEntityCommand
        {
            public Command(SaveDomainViewModel viewModel) : base(viewModel) { }
        }
    }
}
