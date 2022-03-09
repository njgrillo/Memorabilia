using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Memorabilia.Book
{
    public class GetBook
    {
        public class Handler : QueryHandler<Query, BookViewModel>
        {
            private readonly IMemorabiliaRepository _memorabiliaRepository;

            public Handler(IMemorabiliaRepository memorabiliaRepository)
            {
                _memorabiliaRepository = memorabiliaRepository;
            }

            protected override async Task<BookViewModel> Handle(Query query)
            {
                return new BookViewModel(await _memorabiliaRepository.Get(query.MemorabiliaId).ConfigureAwait(false));
            }
        }

        public class Query : MemorabiliaQuery, IQuery<BookViewModel>
        {
            public Query(int memorabiliaId) : base(memorabiliaId) { }
        }
    }
}
