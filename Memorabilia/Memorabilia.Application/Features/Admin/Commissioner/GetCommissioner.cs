using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.Commissioner
{
    public class GetCommissioner
    {
        public class Handler : QueryHandler<Query, CommissionerViewModel>
        {
            private readonly ICommissionerRepository _commissionerRepository;

            public Handler(ICommissionerRepository commissionerRepository)
            {
                _commissionerRepository = commissionerRepository;
            }

            protected override async Task<CommissionerViewModel> Handle(Query query)
            {
                var commissioner = await _commissionerRepository.Get(query.Id).ConfigureAwait(false);

                var viewModel = new CommissionerViewModel(commissioner);

                return viewModel;
            }
        }

        public class Query : IQuery<CommissionerViewModel>
        {
            public Query(int id)
            {
                Id = id;
            }

            public int Id { get; }
        }
    }
}
