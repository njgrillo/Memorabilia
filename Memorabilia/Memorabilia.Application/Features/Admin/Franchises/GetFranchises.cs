using Demo.Framework.Handler;
using Memorabilia.Repository.Interfaces;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.Franchises
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
                return new FranchisesViewModel(await _franchiseRepository.GetAll().ConfigureAwait(false));
            }
        }

        public class Query : IQuery<FranchisesViewModel> { }
    }
}
