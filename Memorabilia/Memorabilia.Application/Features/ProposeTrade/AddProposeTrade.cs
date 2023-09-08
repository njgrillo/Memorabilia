namespace Memorabilia.Application.Features.ProposeTrade;

public class AddProposeTrade
{
    public class Handler : CommandHandler<Command>
    {
        private readonly IProposeTradeRepository _proposeTradeRepository;

        public Handler(IProposeTradeRepository collectionRepository)
        {
            _proposeTradeRepository = collectionRepository;
        }

        protected override async Task Handle(Command command)
        {
            Entity.ProposeTrade proposeTrade
                    = new(command.AmountToReceive,
                          command.AmountToSend,
                          command.ExpirationDate,
                          command.ProposedDate,
                          command.ProposeTradeStatusTypeId,
                          command.ReceiverUserId,
                          command.SenderUserId);

            foreach (ProposeTradeMemorabiliaEditModel item in command.MemorabiliaItems)
            {
                proposeTrade.AddMemorabilia(item.MemorabiliaId, item.ProposeTradeMemorabiliaTypeId);
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

        public decimal? AmountToReceive 
            => _editModel.AmountToReceive;

        public decimal? AmountToSend
            => _editModel.AmountToSend;

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

        public int ReceiverUserId
            => _editModel.ReceiverUser.Id;

        public int SenderUserId
            => _editModel.SenderUser.Id;

        public int SendItemsCount
            => _editModel.SendItemsCount;
    }
}
