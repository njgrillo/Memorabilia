using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Autograph
{
    public class GetAutograph
    {
        public class Handler : QueryHandler<Query, AutographViewModel>
        {
            private readonly IAutographRepository _autographRepository;

            public Handler(IAutographRepository autographRepository)
            {
                _autographRepository = autographRepository;
            }

            protected override async Task<AutographViewModel> Handle(Query query)
            {
                var autograph = await _autographRepository.Get(query.Id).ConfigureAwait(false);

                var viewModel = new AutographViewModel(autograph);

                return viewModel;
            }
        }

        public class Query : IQuery<AutographViewModel>
        {
            public Query(int id)
            {
                Id = id;
            }

            public int Id { get; }
        }
    }
}
