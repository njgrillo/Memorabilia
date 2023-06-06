using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.PurchaseTypes;

public record SavePurchaseType(DomainEditModel ViewModel) : ICommand
{
    public class Handler : CommandHandler<SavePurchaseType>
    {
        private readonly IDomainRepository<PurchaseType> _purchaseTypeRepository;

        public Handler(IDomainRepository<PurchaseType> purchaseTypeRepository)
        {
            _purchaseTypeRepository = purchaseTypeRepository;
        }

        protected override async Task Handle(SavePurchaseType request)
        {
            PurchaseType purchaseType;

            if (request.ViewModel.IsNew)
            {
                purchaseType = new PurchaseType(request.ViewModel.Name, request.ViewModel.Abbreviation);

                await _purchaseTypeRepository.Add(purchaseType);

                return;
            }

            purchaseType = await _purchaseTypeRepository.Get(request.ViewModel.Id);

            if (request.ViewModel.IsDeleted)
            {
                await _purchaseTypeRepository.Delete(purchaseType);

                return;
            }

            purchaseType.Set(request.ViewModel.Name, request.ViewModel.Abbreviation);

            await _purchaseTypeRepository.Update(purchaseType);
        }
    }
}
