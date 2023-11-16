namespace Memorabilia.Application.Features.ProposeTrade;

public record ProcessExpiredProposedTrades()
     : ICommand
{
    public class Handler(IProposeTradeRepository proposeTradeRepository) 
        : CommandHandler<ProcessExpiredProposedTrades>
    {
        protected override async Task Handle(ProcessExpiredProposedTrades command)
        {
            Entity.ProposeTrade[] expiredTrades
                = await proposeTradeRepository.GetAllExpired();

            if (expiredTrades.IsNullOrEmpty())
                return;

            foreach (Entity.ProposeTrade trade in expiredTrades)
            {
                trade.SetStatus(Constant.ProposeTradeStatusType.Expired);

                await proposeTradeRepository.Update(trade);
            }
        }
    }
}
