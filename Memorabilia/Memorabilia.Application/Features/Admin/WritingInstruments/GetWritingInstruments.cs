using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.WritingInstruments;

public record GetWritingInstruments() : IQuery<WritingInstrumentsViewModel>
{
    public class Handler : QueryHandler<GetWritingInstruments, WritingInstrumentsViewModel>
    {
        private readonly IDomainRepository<WritingInstrument> _writingInstrumentRepository;

        public Handler(IDomainRepository<WritingInstrument> writingInstrumentRepository)
        {
            _writingInstrumentRepository = writingInstrumentRepository;
        }

        protected override async Task<WritingInstrumentsViewModel> Handle(GetWritingInstruments query)
        {
            return new WritingInstrumentsViewModel(await _writingInstrumentRepository.GetAll());
        }
    }
}
