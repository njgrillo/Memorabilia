namespace Memorabilia.Application.Features.ProposeTrade;

public class AddProposeTrade
{
    public class Handler : CommandHandler<Command>
    {
        private readonly IProposeTradeRepository _proposeTradeRepository;

        public Handler(IProposeTradeRepository proposeTradeRepository)
        {
            _proposeTradeRepository = proposeTradeRepository;
        }

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

            await _proposeTradeRepository.Add(proposeTrade);
        }
    }

    public class Command : DomainCommand, ICommand
    {
        private readonly ProposeTradeEditModel _editModel;

        public Command(ProposeTradeEditModel editModel)
        {
            _editModel = editModel;
        }

        public decimal? AmountTradeCreatorToReceive
            => _editModel.UserId == _editModel.ProposeTradeCreateUser.Id
                ? _editModel.AmountToReceive
                : _editModel.AmountToSend;

        public decimal? AmountTradeCreatorToSend
            => _editModel.UserId == _editModel.ProposeTradeCreateUser.Id
                ? _editModel.AmountToSend
                : _editModel.AmountToReceive;

        public DateTime ExpirationDate
            => DateTime.UtcNow.AddDays(3); //TODO:Look into datetime offset && Dropdown option

        public ProposeTradeMemorabiliaEditModel[] MemorabiliaItems
            => _editModel.ReceiveItems
                         .Union(_editModel.SendItems)
                         .Where(item => !item.IsDeleted)
                         .ToArray();

        public DateTime ProposedDate
            => DateTime.UtcNow; //TODO:Look into datetime offset

        public int ProposeTradeStatusTypeId
            => _editModel.ProposeTradeStatusTypeId;

        public int ReceiveItemsCount
            => _editModel.ReceiveItemsCount;

        public int SendItemsCount
            => _editModel.SendItemsCount;

        public int TradeCreatorUserId
            => _editModel.ProposeTradeCreateUser.Id;

        public int TradePartnerUserId
            => _editModel.ProposeTradePartnerUser.Id;
    }
}
