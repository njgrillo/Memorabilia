using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.WritingInstruments;

public class GetWritingInstrument
{
    public class Handler : QueryHandler<Query, DomainViewModel>
    {
        private readonly IDomainRepository<WritingInstrument> _writingInstrumentRepository;

        public Handler(IDomainRepository<WritingInstrument> writingInstrumentRepository)
        {
            _writingInstrumentRepository = writingInstrumentRepository;
        }

        protected override async Task<DomainViewModel> Handle(Query query)
        {
            return new DomainViewModel(await _writingInstrumentRepository.Get(query.Id));
        }
    }

    public class Query : DomainQuery
    {
        public Query(int id) : base(id) { }
    }
}
