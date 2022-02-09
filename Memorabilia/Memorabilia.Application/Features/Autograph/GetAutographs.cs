using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Autograph
{
    public class GetAutographs
    {
        public class Handler : QueryHandler<Query, AutographsViewModel>
        {
            private readonly IAutographRepository _autographRepository;

            public Handler(IAutographRepository autographRepository)
            {
                _autographRepository = autographRepository;
            }

            protected override async Task<AutographsViewModel> Handle(Query query)
            {
                var autograph = await _autographRepository.GetAll(query.MemorabiliaId).ConfigureAwait(false);

                var viewModel = new AutographsViewModel(autograph);

                return viewModel;
            }
        }

        public class Query : IQuery<AutographsViewModel>
        {
            public Query(int? memorabiliaId = null)
            {
                MemorabiliaId = memorabiliaId;
            }

            public int? MemorabiliaId { get; }
        }
    }
}
