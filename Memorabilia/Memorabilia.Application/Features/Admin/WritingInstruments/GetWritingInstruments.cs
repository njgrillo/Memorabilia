using Demo.Framework.Handler;
using Memorabilia.Repository.Interfaces;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.WritingInstruments
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
                return new WritingInstrumentsViewModel(await _writingInstrumentRepository.GetAll().ConfigureAwait(false));
            }
        }

        public class Query : IQuery<WritingInstrumentsViewModel> { }
    }
}
