using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.Franchise
{
    public class GetFranchise
    {
        public class Handler : QueryHandler<Query, FranchiseViewModel>
        {
            private readonly IFranchiseRepository _franchiseRepository;

            public Handler(IFranchiseRepository franchiseRepository)
            {
                _franchiseRepository = franchiseRepository;
            }

            protected override async Task<FranchiseViewModel> Handle(Query query)
            {
                var franchise = await _franchiseRepository.Get(query.Id).ConfigureAwait(false);

                var viewModel = new FranchiseViewModel(franchise);

                return viewModel;
            }
        }

        public class Query : IQuery<FranchiseViewModel>
        {
            public Query(int id)
            {
                Id = id;
            }

            public int Id { get; }
        }
    }
}
