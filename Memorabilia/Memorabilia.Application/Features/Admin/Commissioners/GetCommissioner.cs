using Demo.Framework.Handler;
using Memorabilia.Repository.Interfaces;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.Commissioners
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
                return new CommissionerViewModel(await _commissionerRepository.Get(query.Id).ConfigureAwait(false));
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
