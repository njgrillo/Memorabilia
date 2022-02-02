using Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.PurchaseType
{
    public class SavePurchaseType
    {
        public class Handler : CommandHandler<Command>
        {
            private readonly IPurchaseTypeRepository _purchaseTypeRepository;

            public Handler(IPurchaseTypeRepository purchaseTypeRepository)
            {
                _purchaseTypeRepository = purchaseTypeRepository;
            }

            protected override async Task Handle(Command command)
            {
                Domain.Entities.PurchaseType purchaseType;

                if (command.IsNew)
                {
                    purchaseType = new Domain.Entities.PurchaseType(command.Name, command.Abbreviation);
                    await _purchaseTypeRepository.Add(purchaseType).ConfigureAwait(false);

                    return;
                }

                purchaseType = await _purchaseTypeRepository.Get(command.Id).ConfigureAwait(false);

                if (command.IsDeleted)
                {
                    await _purchaseTypeRepository.Delete(purchaseType).ConfigureAwait(false);

                    return;
                }

                purchaseType.Set(command.Name, command.Abbreviation);

                await _purchaseTypeRepository.Update(purchaseType).ConfigureAwait(false);
            }
        }

        public class Command : DomainEntityCommand
        {
            public Command(SaveDomainViewModel viewModel) : base(viewModel)
            {
            }
        }
    }
}
