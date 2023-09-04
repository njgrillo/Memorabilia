namespace Memorabilia.Application.Features.Admin.PurchaseTypes;

[AuthorizeByRole(Enum.PermissionType.Admin)]
public record SavePurchaseType(DomainEditModel PurchaseType) : ICommand
{
    public class Handler : CommandHandler<SavePurchaseType>
    {
        private readonly IDomainRepository<Entity.PurchaseType> _purchaseTypeRepository;

        public Handler(IDomainRepository<Entity.PurchaseType> purchaseTypeRepository)
        {
            _purchaseTypeRepository = purchaseTypeRepository;
        }

        protected override async Task Handle(SavePurchaseType request)
        {
            Entity.PurchaseType purchaseType;

            if (request.PurchaseType.IsNew)
            {
                purchaseType = new Entity.PurchaseType(request.PurchaseType.Name, 
                                                       request.PurchaseType.Abbreviation);

                await _purchaseTypeRepository.Add(purchaseType);

                return;
            }

            purchaseType = await _purchaseTypeRepository.Get(request.PurchaseType.Id);

            if (request.PurchaseType.IsDeleted)
            {
                await _purchaseTypeRepository.Delete(purchaseType);

                return;
            }

            purchaseType.Set(request.PurchaseType.Name, 
                             request.PurchaseType.Abbreviation);

            await _purchaseTypeRepository.Update(purchaseType);
        }
    }
}
