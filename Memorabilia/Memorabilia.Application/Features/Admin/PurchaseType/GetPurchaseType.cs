using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.PurchaseType
{
    public class GetPurchaseType
    {
        public class Handler : QueryHandler<Query, DomainViewModel>
        {
            private readonly IPurchaseTypeRepository _purchaseTypeRepository;

            public Handler(IPurchaseTypeRepository purchaseTypeRepository)
            {
                _purchaseTypeRepository = purchaseTypeRepository;
            }

            protected override async Task<DomainViewModel> Handle(Query query)
            {
                var purchaseType = await _purchaseTypeRepository.Get(query.Id).ConfigureAwait(false);

                var viewModel = new DomainViewModel(purchaseType);

                return viewModel;
            }
        }

        public class Query : DomainQuery
        {
            public Query(int id) : base(id)
            {
            }
        }
    }
}
