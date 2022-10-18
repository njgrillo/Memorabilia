using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.WritingInstruments;

public record GetWritingInstrument(int Id) : IQuery<DomainViewModel>
{
    public class Handler : QueryHandler<GetWritingInstrument, DomainViewModel>
    {
        private readonly IDomainRepository<WritingInstrument> _writingInstrumentRepository;

        public Handler(IDomainRepository<WritingInstrument> writingInstrumentRepository)
        {
            _writingInstrumentRepository = writingInstrumentRepository;
        }

        protected override async Task<DomainViewModel> Handle(GetWritingInstrument query)
        {
            return new DomainViewModel(await _writingInstrumentRepository.Get(query.Id));
        }
    }
}
