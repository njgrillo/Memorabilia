namespace Memorabilia.Application.Features.ForSale;

[AuthorizeByPermission(Enum.Permission.BuySellTrade)]
public class SaveForSaleMemorabilia
{
    public class Handler(IMemorabiliaForSaleRepository memorabiliaForSaleRepository,
                         IMemorabiliaItemRepository memorabiliaRepository) 
        : CommandHandler<Command>
    {
        protected override async Task Handle(Command command)
        {
            if (command.ForSaleItems.IsNullOrEmpty() && command.RemovedIds.IsNullOrEmpty())
                return;

            if (command.RemovedIds.HasAny())
            {
                Entity.MemorabiliaForSale[] removedItems = await memorabiliaForSaleRepository.GetAll(command.RemovedIds);

                foreach (Entity.MemorabiliaForSale item in removedItems)
                {
                    await memorabiliaForSaleRepository.Delete(item);
                }
            }

            if (command.ForSaleItems.HasAny())
            {
                Entity.Memorabilia[] memorabilias = await memorabiliaRepository.GetAll(command.MemorabiliaIds);

                foreach (ForSaleMemorabiliaEditModel forSaleItem in command.ForSaleItems)
                {
                    Entity.Memorabilia memorabilia = memorabilias.Single(item => item.Id == forSaleItem.MemorabiliaId);

                    memorabilia.SetForSale(forSaleItem.BuyNowPrice, forSaleItem.AllowBestOffer, forSaleItem.MinimumOfferPrice);

                    await memorabiliaRepository.Update(memorabilia);
                }
            }                       
        }
    }

    public class Command : DomainCommand, ICommand
    {
        private readonly ForSaleEditModel _forSaleEditModel;

        public Command(ForSaleEditModel forSaleEditModel)
        {
            _forSaleEditModel = forSaleEditModel;
        }

        public Command(int[] removedIds)
        {
            RemovedIds = removedIds;
        }

        public ForSaleMemorabiliaEditModel[] ForSaleItems
            => _forSaleEditModel?.Items
                                 .ToArray()
                ?? [];

        public int[] MemorabiliaIds
            => _forSaleEditModel?.Items
                                 .Select(item => item.MemorabiliaId)
                                 .ToArray()
                ?? [];

        public int[] RemovedIds { get; set; }
            = [];
    }
}
