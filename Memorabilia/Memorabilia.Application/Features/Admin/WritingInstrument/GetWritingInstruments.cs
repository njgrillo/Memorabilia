using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.WritingInstrument
{
    public class GetWritingInstruments
    {
        public class Handler : QueryHandler<Query, WritingInstrumentsViewModel>
        {
            private readonly IWritingInstrumentRepository _writingInstrumentRepository;

            public Handler(IWritingInstrumentRepository writingInstrumentRepository)
            {
                _writingInstrumentRepository = writingInstrumentRepository;
            }

            protected override async Task<WritingInstrumentsViewModel> Handle(Query query)
            {
                var writingInstruments = await _writingInstrumentRepository.GetAll().ConfigureAwait(false);

                var viewModel = new WritingInstrumentsViewModel(writingInstruments);

                return viewModel;
            }
        }

        public class Query : IQuery<WritingInstrumentsViewModel> { }
    }
}
