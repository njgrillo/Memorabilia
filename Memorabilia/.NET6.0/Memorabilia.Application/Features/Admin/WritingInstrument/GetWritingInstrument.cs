using Demo.Framework.Handler;
using Memorabilia.Domain;

namespace Memorabilia.Application.Features.Admin.WritingInstrument
{
    public class GetWritingInstrument
    {
        public class Handler : QueryHandler<DomainQuery, DomainViewModel>
        {
            private readonly IWritingInstrumentRepository _writingInstrumentRepository;

            public Handler(IWritingInstrumentRepository writingInstrumentRepository)
            {
                _writingInstrumentRepository = writingInstrumentRepository;
            }

            protected override async Task<DomainViewModel> Handle(DomainQuery query)
            {
                var writingInstrument = await _writingInstrumentRepository.Get(query.Id).ConfigureAwait(false);

                var viewModel = new DomainViewModel(writingInstrument);

                return viewModel;
            }
        }
    }
}
