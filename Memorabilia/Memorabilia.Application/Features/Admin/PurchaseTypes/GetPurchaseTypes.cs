using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.PurchaseTypes;

public record GetPurchaseTypes() : IQuery<PurchaseTypesViewModel>
{
    public class Handler : QueryHandler<GetPurchaseTypes, PurchaseTypesViewModel>
    {
        private readonly IDomainRepository<PurchaseType> _purchaseTypeRepository;

        public Handler(IDomainRepository<PurchaseType> purchaseTypeRepository)
        {
            _purchaseTypeRepository = purchaseTypeRepository;
        }

        protected override async Task<PurchaseTypesViewModel> Handle(GetPurchaseTypes query)
        {
            return new PurchaseTypesViewModel(await _purchaseTypeRepository.GetAll());
        }
    }
}
