using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.PurchaseTypes;

public record GetPurchaseType(int Id) : IQuery<DomainModel>
{
    public class Handler : QueryHandler<GetPurchaseType, DomainModel>
    {
        private readonly IDomainRepository<PurchaseType> _purchaseTypeRepository;

        public Handler(IDomainRepository<PurchaseType> purchaseTypeRepository)
        {
            _purchaseTypeRepository = purchaseTypeRepository;
        }

        protected override async Task<DomainModel> Handle(GetPurchaseType query)
        {
            return new DomainModel(await _purchaseTypeRepository.Get(query.Id));
        }
    }
}
