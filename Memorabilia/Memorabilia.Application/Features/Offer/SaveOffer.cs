namespace Memorabilia.Application.Features.Offer;

[AuthorizeByPermission(Enum.Permission.BuySellTrade)]
public class SaveOffer
{
    public class Handler : CommandHandler<Command>
    {
        private readonly IOfferRepository _offerRepository;

        public Handler(IOfferRepository offerRepository)
        {
            _offerRepository = offerRepository;
        }

        protected override async Task Handle(Command command)
        {
            Entity.Offer offer;

            if (command.IsNew)
            {
                offer
                   = new(command.Amount,
                         command.BuyerId,
                         command.OfferStatusTypeId,
                         command.ExpirationDate,
                         command.MemorabiliaId,
                         command.OfferDate,
                         command.SellerId);

                await _offerRepository.Add(offer);

                return;
            }

            offer = await _offerRepository.Get(command.Id);

            offer.Set(command.Amount,
                      command.OfferStatusTypeId,
                      command.ExpirationDate,
                      command.OfferDate);

            await _offerRepository.Update(offer);
        }
    }

    public class Command : DomainCommand, ICommand
    {
        private readonly OfferEditModel _editModel;

        public Command(OfferEditModel editModel)
        {
            _editModel = editModel;
        }

        public decimal Amount
            => _editModel.Amount.Value;

        public int BuyerId
            => _editModel.BuyerId;

        public DateTime ExpirationDate
            => DateTime.UtcNow.AddDays(3); //TODO:Look into datetime offset && Dropdown option

        public int Id
            => _editModel.Id;

        public bool IsNew
            => _editModel.IsNew;

        public int MemorabiliaId
            => _editModel.MemorabiliaId;

        public DateTime OfferDate
            => DateTime.UtcNow; //TODO:Look into datetime offset

        public int OfferStatusTypeId
            => _editModel.OfferStatusTypeId;

        public int SellerId
            => _editModel.SellerId;
    }
}
