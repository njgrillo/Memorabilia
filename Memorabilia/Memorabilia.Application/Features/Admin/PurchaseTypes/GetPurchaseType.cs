namespace Memorabilia.Application.Features.Admin.PurchaseTypes;

[AuthorizeByRole(Enum.Role.Admin)]
public record GetPurchaseType(int Id) : IQuery<Entity.DomainEntity>
{
    public class Handler : QueryHandler<GetPurchaseType, Entity.DomainEntity>
    {
        private readonly IDomainRepository<Entity.PurchaseType> _purchaseTypeRepository;

        public Handler(IDomainRepository<Entity.PurchaseType> purchaseTypeRepository)
        {
            _purchaseTypeRepository = purchaseTypeRepository;
        }

        protected override async Task<Entity.DomainEntity> Handle(GetPurchaseType query)
            => await _purchaseTypeRepository.Get(query.Id);
    }
}
