using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.Commissioner
{
    public class GetCommissioners : ViewModel
    {
        public class Handler : QueryHandler<Query, CommissionersViewModel>
        {
            private readonly ICommissionerRepository _commissionerRepository;

            public Handler(ICommissionerRepository commissionerRepository)
            {
                _commissionerRepository = commissionerRepository;
            }

            protected override async Task<CommissionersViewModel> Handle(Query query)
            {
                var commissioners = await _commissionerRepository.GetAll(query.SportId).ConfigureAwait(false);

                var viewModel = new CommissionersViewModel(commissioners);

                return viewModel;
            }
        }

        public class Query : IQuery<CommissionersViewModel>
        {
            public Query(int? sportId = null)
            {
                SportId = sportId;
            }

            public int? SportId { get; }
        }
    }
}
