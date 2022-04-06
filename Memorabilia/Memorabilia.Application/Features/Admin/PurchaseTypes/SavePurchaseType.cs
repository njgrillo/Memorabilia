using Framework.Handler;
using Memorabilia.Domain.Entities;
using Memorabilia.Repository.Interfaces;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.PurchaseTypes
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
                PurchaseType purchaseType;

                if (command.IsNew)
                {
                    purchaseType = new PurchaseType(command.Name, command.Abbreviation);
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
            public Command(SaveDomainViewModel viewModel) : base(viewModel) { }
        }
    }
}
