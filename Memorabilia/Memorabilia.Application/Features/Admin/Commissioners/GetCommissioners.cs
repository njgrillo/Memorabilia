using Demo.Framework.Handler;
using Memorabilia.Repository.Interfaces;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.Commissioners
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
                return new CommissionersViewModel(await _commissionerRepository.GetAll(query.SportId).ConfigureAwait(false));
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
