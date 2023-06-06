using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.WritingInstruments;

public record SaveWritingInstrument(DomainEditModel ViewModel) : ICommand
{
    public class Handler : CommandHandler<SaveWritingInstrument>
    {
        private readonly IDomainRepository<WritingInstrument> _writingInstrumentRepository;

        public Handler(IDomainRepository<WritingInstrument> writingInstrumentRepository)
        {
            _writingInstrumentRepository = writingInstrumentRepository;
        }

        protected override async Task Handle(SaveWritingInstrument request)
        {
            WritingInstrument writingInstrument;

            if (request.ViewModel.IsNew)
            {
                writingInstrument = new WritingInstrument(request.ViewModel.Name, request.ViewModel.Abbreviation);

                await _writingInstrumentRepository.Add(writingInstrument);

                return;
            }

            writingInstrument = await _writingInstrumentRepository.Get(request.ViewModel.Id);

            if (request.ViewModel.IsDeleted)
            {
                await _writingInstrumentRepository.Delete(writingInstrument);

                return;
            }

            writingInstrument.Set(request.ViewModel.Name, request.ViewModel.Abbreviation);

            await _writingInstrumentRepository.Update(writingInstrument);
        }
    }
}
