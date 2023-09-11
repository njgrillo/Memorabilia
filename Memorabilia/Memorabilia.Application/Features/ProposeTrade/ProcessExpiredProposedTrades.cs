namespace Memorabilia.Application.Features.ProposeTrade;

public record ProcessExpiredProposedTrades()
     : ICommand
{
    public class Handler : CommandHandler<ProcessExpiredProposedTrades>
    {
        private readonly IProposeTradeRepository _proposeTradeRepository;

        public Handler(IProposeTradeRepository proposeTradeRepository)
        {
            _proposeTradeRepository = proposeTradeRepository;
        }

        protected override async Task Handle(ProcessExpiredProposedTrades command)
        {
            Entity.ProposeTrade[] expiredTrades
                = await _proposeTradeRepository.GetAllExpired();

            if (!expiredTrades.Any())
                return;

            foreach (Entity.ProposeTrade trade in expiredTrades)
            {
                trade.SetStatus(Constant.ProposeTradeStatusType.Expired);

                await _proposeTradeRepository.Update(trade);
            }
        }
    }
}
