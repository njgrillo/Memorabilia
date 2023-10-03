namespace Memorabilia.Application.Features.ForSale;

[AuthorizeByPermission(Enum.Permission.BuySellTrade)]
public class SaveForSaleMemorabilia
{
    public class Handler : CommandHandler<Command>
    {
        private readonly IMemorabiliaForSaleRepository _memorabiliaForSaleRepository;
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaForSaleRepository memorabiliaForSaleRepository,
            IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaForSaleRepository = memorabiliaForSaleRepository;
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task Handle(Command command)
        {
            if (command.ForSaleItems.Length == 0 && command.RemovedIds.Length == 0)
                return;

            if (command.RemovedIds.Length > 0)
            {
                Entity.MemorabiliaForSale[] removedItems = await _memorabiliaForSaleRepository.GetAll(command.RemovedIds);

                foreach (Entity.MemorabiliaForSale item in removedItems)
                {
                    await _memorabiliaForSaleRepository.Delete(item);
                }
            }

            if (command.ForSaleItems.Length > 0)
            {
                Entity.Memorabilia[] memorabilias = await _memorabiliaRepository.GetAll(command.MemorabiliaIds);

                foreach (ForSaleMemorabiliaEditModel forSaleItem in command.ForSaleItems)
                {
                    Entity.Memorabilia memorabilia = memorabilias.Single(item => item.Id == forSaleItem.MemorabiliaId);

                    memorabilia.SetForSale(forSaleItem.BuyNowPrice, forSaleItem.AllowBestOffer, forSaleItem.MinimumOfferPrice);

                    await _memorabiliaRepository.Update(memorabilia);
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
                ?? Array.Empty<ForSaleMemorabiliaEditModel>();

        public int[] MemorabiliaIds
            => _forSaleEditModel?.Items
                                 .Select(item => item.MemorabiliaId)
                                 .ToArray()
                ?? Array.Empty<int>();

        public int[] RemovedIds { get; set; }
            = Array.Empty<int>();
    }
}
