using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.WritingInstrument
{
    public class GetWritingInstrument
    {
        public class Handler : QueryHandler<Query, DomainViewModel>
        {
            private readonly IWritingInstrumentRepository _writingInstrumentRepository;

            public Handler(IWritingInstrumentRepository writingInstrumentRepository)
            {
                _writingInstrumentRepository = writingInstrumentRepository;
            }

            protected override async Task<DomainViewModel> Handle(Query query)
            {
                var writingInstrument = await _writingInstrumentRepository.Get(query.Id).ConfigureAwait(false);

                var viewModel = new DomainViewModel(writingInstrument);

                return viewModel;
            }
        }

        public class Query : DomainQuery
        {
            public Query(int id) : base(id) { }
        }
    }
}
