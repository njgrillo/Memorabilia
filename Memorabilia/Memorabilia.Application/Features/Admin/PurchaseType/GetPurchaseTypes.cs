using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.PurchaseType
{
    public class GetPurchaseTypes
    {
        public class Handler : QueryHandler<Query, PurchaseTypesViewModel>
        {
            private readonly IPurchaseTypeRepository _purchaseTypeRepository;

            public Handler(IPurchaseTypeRepository purchaseTypeRepository)
            {
                _purchaseTypeRepository = purchaseTypeRepository;
            }

            protected override async Task<PurchaseTypesViewModel> Handle(Query query)
            {
                var purchaseTypes = await _purchaseTypeRepository.GetAll().ConfigureAwait(false);

                var viewModel = new PurchaseTypesViewModel(purchaseTypes);

                return viewModel;
            }
        }

        public class Query : IQuery<PurchaseTypesViewModel> { }
    }
}
