namespace Memorabilia.Application.Features.ProposeTrade;

[AuthorizeByPermission(Enum.Permission.BuySellTrade)]
public class AddProposeTrade
{
    public class Handler(IProposeTradeRepository proposeTradeRepository) 
        : CommandHandler<Command>
    {
        protected override async Task Handle(Command command)
        {
            Entity.ProposeTrade proposeTrade
                    = new(command.AmountTradeCreatorToReceive,
                          command.AmountTradeCreatorToSend,
                          command.ExpirationDate,
                          command.ProposedDate,
                          command.ProposeTradeStatusTypeId,
                          command.TradeCreatorUserId,
                          command.TradePartnerUserId);

            foreach (ProposeTradeMemorabiliaEditModel item in command.MemorabiliaItems)
            {
                proposeTrade.AddMemorabilia(item.MemorabiliaId, item.UserId);
            }

            await proposeTradeRepository.Add(proposeTrade);
        }
    }

    public class Command(ProposeTradeEditModel editModel) 
        : DomainCommand, ICommand
    {
        public decimal? AmountTradeCreatorToReceive
            => editModel.UserId == editModel.ProposeTradeCreateUser.Id
                ? editModel.AmountToReceive
                : editModel.AmountToSend;

        public decimal? AmountTradeCreatorToSend
            => editModel.UserId == editModel.ProposeTradeCreateUser.Id
                ? editModel.AmountToSend
                : editModel.AmountToReceive;

        public DateTime ExpirationDate
            => DateTime.UtcNow.AddDays(3); //TODO:Look into datetime offset && Dropdown option

        public ProposeTradeMemorabiliaEditModel[] MemorabiliaItems
            => editModel.ReceiveItems
                         .Union(editModel.SendItems)
                         .Where(item => !item.IsDeleted)
                         .ToArray();

        public DateTime ProposedDate
            => DateTime.UtcNow; //TODO:Look into datetime offset

        public int ProposeTradeStatusTypeId
            => editModel.ProposeTradeStatusTypeId;

        public int ReceiveItemsCount
            => editModel.ReceiveItemsCount;

        public int SendItemsCount
            => editModel.SendItemsCount;

        public int TradeCreatorUserId
            => editModel.ProposeTradeCreateUser.Id;

        public int TradePartnerUserId
            => editModel.ProposeTradePartnerUser.Id;
    }
}
