using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.PurchaseTypes;

public class SavePurchaseType
{
    public class Handler : CommandHandler<Command>
    {
        private readonly IDomainRepository<PurchaseType> _purchaseTypeRepository;

        public Handler(IDomainRepository<PurchaseType> purchaseTypeRepository)
        {
            _purchaseTypeRepository = purchaseTypeRepository;
        }

        protected override async Task Handle(Command command)
        {
            PurchaseType purchaseType;

            if (command.IsNew)
            {
                purchaseType = new PurchaseType(command.Name, command.Abbreviation);

                await _purchaseTypeRepository.Add(purchaseType);

                return;
            }

            purchaseType = await _purchaseTypeRepository.Get(command.Id);

            if (command.IsDeleted)
            {
                await _purchaseTypeRepository.Delete(purchaseType);

                return;
            }

            purchaseType.Set(command.Name, command.Abbreviation);

            await _purchaseTypeRepository.Update(purchaseType);
        }
    }

    public class Command : DomainEntityCommand
    {
        public Command(SaveDomainViewModel viewModel) : base(viewModel) { }
    }
}
