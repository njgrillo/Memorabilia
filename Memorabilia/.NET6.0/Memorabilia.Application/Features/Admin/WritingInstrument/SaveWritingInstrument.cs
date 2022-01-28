using Framework.Handler;
using Memorabilia.Domain;

namespace Memorabilia.Application.Features.Admin.WritingInstrument
{
    public class SaveWritingInstrument
    {
        public class Handler : CommandHandler<DomainEntityCommand>
        {
            private readonly IWritingInstrumentRepository _writingInstrumentRepository;

            public Handler(IWritingInstrumentRepository writingInstrumentRepository)
            {
                _writingInstrumentRepository = writingInstrumentRepository;
            }

            protected override async Task Handle(DomainEntityCommand command)
            {
                Domain.Entities.WritingInstrument writingInstrument;

                if (command.IsNew)
                {
                    writingInstrument = new Domain.Entities.WritingInstrument(command.Name, command.Abbreviation);
                    await _writingInstrumentRepository.Add(writingInstrument).ConfigureAwait(false);

                    return;
                }

                writingInstrument = await _writingInstrumentRepository.Get(command.Id).ConfigureAwait(false);

                if (command.IsDeleted)
                {
                    await _writingInstrumentRepository.Delete(writingInstrument).ConfigureAwait(false);

                    return;
                }

                writingInstrument.Set(command.Name, command.Abbreviation);

                await _writingInstrumentRepository.Update(writingInstrument).ConfigureAwait(false);
            }
        }
    }
}
