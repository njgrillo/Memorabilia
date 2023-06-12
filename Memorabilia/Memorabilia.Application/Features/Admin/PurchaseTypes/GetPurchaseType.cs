namespace Memorabilia.Application.Features.Admin.PurchaseTypes;

public record GetPurchaseType(int Id) : IQuery<Entity.PurchaseType>
{
    public class Handler : QueryHandler<GetPurchaseType, Entity.PurchaseType>
    {
        private readonly IDomainRepository<Entity.PurchaseType> _purchaseTypeRepository;

        public Handler(IDomainRepository<Entity.PurchaseType> purchaseTypeRepository)
        {
            _purchaseTypeRepository = purchaseTypeRepository;
        }

        protected override async Task<Entity.PurchaseType> Handle(GetPurchaseType query)
            => await _purchaseTypeRepository.Get(query.Id);
    }
}
