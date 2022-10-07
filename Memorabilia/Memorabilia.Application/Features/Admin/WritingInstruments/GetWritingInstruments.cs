using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.WritingInstruments;

public class GetWritingInstruments
{
    public class Handler : QueryHandler<Query, WritingInstrumentsViewModel>
    {
        private readonly IDomainRepository<WritingInstrument> _writingInstrumentRepository;

        public Handler(IDomainRepository<WritingInstrument> writingInstrumentRepository)
        {
            _writingInstrumentRepository = writingInstrumentRepository;
        }

        protected override async Task<WritingInstrumentsViewModel> Handle(Query query)
        {
            return new WritingInstrumentsViewModel(await _writingInstrumentRepository.GetAll());
        }
    }

    public class Query : IQuery<WritingInstrumentsViewModel> { }
}
