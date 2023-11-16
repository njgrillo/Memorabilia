namespace Memorabilia.Application.Features.Offer;

[AuthorizeByPermission(Enum.Permission.BuySellTrade)]
public class SaveOffer
{
    public class Handler(IOfferRepository offerRepository) 
        : CommandHandler<Command>
    {
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

                await offerRepository.Add(offer);

                return;
            }

            offer = await offerRepository.Get(command.Id);

            offer.Set(command.Amount,
                      command.OfferStatusTypeId,
                      command.ExpirationDate,
                      command.OfferDate);

            await offerRepository.Update(offer);
        }
    }

    public class Command(OfferEditModel editModel) 
        : DomainCommand, ICommand
    {
        public decimal Amount
            => editModel.Amount.Value;

        public int BuyerId
            => editModel.BuyerId;

        public DateTime ExpirationDate
            => DateTime.UtcNow.AddDays(3); //TODO:Look into datetime offset && Dropdown option

        public int Id
            => editModel.Id;

        public bool IsNew
            => editModel.IsNew;

        public int MemorabiliaId
            => editModel.MemorabiliaId;

        public DateTime OfferDate
            => DateTime.UtcNow; //TODO:Look into datetime offset

        public int OfferStatusTypeId
            => editModel.OfferStatusTypeId;

        public int SellerId
            => editModel.SellerId;
    }
}
