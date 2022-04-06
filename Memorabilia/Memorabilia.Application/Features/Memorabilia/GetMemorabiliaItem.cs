using Demo.Framework.Handler;
using Memorabilia.Repository.Interfaces;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Memorabilia
{
    public class GetMemorabiliaItem
    {
        public class Handler : QueryHandler<Query, MemorabiliaItemViewModel>
        {
            private readonly IMemorabiliaRepository _memorabiliaRepository;

            public Handler(IMemorabiliaRepository memorabiliaRepository)
            {
                _memorabiliaRepository = memorabiliaRepository;
            }

            protected override async Task<MemorabiliaItemViewModel> Handle(Query query)
            {
                return new MemorabiliaItemViewModel(await _memorabiliaRepository.Get(query.Id).ConfigureAwait(false));
            }
        }

        public class Query : IQuery<MemorabiliaItemViewModel>
        {
            public Query(int id)
            {
                Id = id;
            }

            public int Id { get; }
        }
    }
}
