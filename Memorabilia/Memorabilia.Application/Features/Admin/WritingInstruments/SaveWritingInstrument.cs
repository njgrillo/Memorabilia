using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.WritingInstruments;

public class SaveWritingInstrument
{
    public class Handler : CommandHandler<Command>
    {
        private readonly IDomainRepository<WritingInstrument> _writingInstrumentRepository;

        public Handler(IDomainRepository<WritingInstrument> writingInstrumentRepository)
        {
            _writingInstrumentRepository = writingInstrumentRepository;
        }

        protected override async Task Handle(Command command)
        {
            Domain.Entities.WritingInstrument writingInstrument;

            if (command.IsNew)
            {
                writingInstrument = new Domain.Entities.WritingInstrument(command.Name, command.Abbreviation);

                await _writingInstrumentRepository.Add(writingInstrument);

                return;
            }

            writingInstrument = await _writingInstrumentRepository.Get(command.Id);

            if (command.IsDeleted)
            {
                await _writingInstrumentRepository.Delete(writingInstrument);

                return;
            }

            writingInstrument.Set(command.Name, command.Abbreviation);

            await _writingInstrumentRepository.Update(writingInstrument);
        }
    }

    public class Command : DomainEntityCommand
    {
        public Command(SaveDomainViewModel viewModel) : base(viewModel) { }
    }
}
