namespace Memorabilia.Application.Features.ProposeTrade;

public record UpdateProposeTradeStatus(int ProposeTradeId, Constant.ProposeTradeStatusType Status)
     : ICommand
{
    public class Handler : CommandHandler<UpdateProposeTradeStatus>
    {
        private readonly IProposeTradeRepository _proposeTradeRepository;

        public Handler(IProposeTradeRepository proposeTradeRepository)
        {
            _proposeTradeRepository = proposeTradeRepository;
        }

        protected override async Task Handle(UpdateProposeTradeStatus command)
        {
            Entity.ProposeTrade proposeTrade 
                = await _proposeTradeRepository.Get(command.ProposeTradeId);

            proposeTrade.SetStatus(command.Status);

            await _proposeTradeRepository.Update(proposeTrade);
        }
    }
}
