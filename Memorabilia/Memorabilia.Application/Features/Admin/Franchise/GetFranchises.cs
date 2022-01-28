using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.Franchise
{
    public class GetFranchises
    {
        public class Handler : QueryHandler<Query, FranchisesViewModel>
        {
            private readonly IFranchiseRepository _franchiseRepository;

            public Handler(IFranchiseRepository franchiseRepository)
            {
                _franchiseRepository = franchiseRepository;
            }

            protected override async Task<FranchisesViewModel> Handle(Query query)
            {
                var franchises = await _franchiseRepository.GetAll().ConfigureAwait(false);

                var viewModel = new FranchisesViewModel(franchises);

                return viewModel;
            }
        }

        public class Query : IQuery<FranchisesViewModel>
        {
        }
    }
}
