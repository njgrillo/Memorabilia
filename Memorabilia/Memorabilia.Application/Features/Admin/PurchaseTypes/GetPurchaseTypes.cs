namespace Memorabilia.Application.Features.Admin.PurchaseTypes
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
                return new PurchaseTypesViewModel(await _purchaseTypeRepository.GetAll().ConfigureAwait(false));
            }
        }

        public class Query : IQuery<PurchaseTypesViewModel> { }
    }
}
