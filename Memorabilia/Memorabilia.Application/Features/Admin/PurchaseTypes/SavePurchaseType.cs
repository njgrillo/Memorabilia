namespace Memorabilia.Application.Features.Admin.PurchaseTypes;

[AuthorizeByRole(Enum.Role.Admin)]
public record SavePurchaseType(DomainEditModel PurchaseType) : ICommand
{
    public class Handler(IDomainRepository<Entity.PurchaseType> purchaseTypeRepository) 
        : CommandHandler<SavePurchaseType>
    {
        protected override async Task Handle(SavePurchaseType request)
        {
            Entity.PurchaseType purchaseType;

            if (request.PurchaseType.IsNew)
            {
                purchaseType = new Entity.PurchaseType(request.PurchaseType.Name, 
                                                       request.PurchaseType.Abbreviation);

                await purchaseTypeRepository.Add(purchaseType);

                return;
            }

            purchaseType = await purchaseTypeRepository.Get(request.PurchaseType.Id);

            if (request.PurchaseType.IsDeleted)
            {
                await purchaseTypeRepository.Delete(purchaseType);

                return;
            }

            purchaseType.Set(request.PurchaseType.Name, 
                             request.PurchaseType.Abbreviation);

            await purchaseTypeRepository.Update(purchaseType);
        }
    }
}
