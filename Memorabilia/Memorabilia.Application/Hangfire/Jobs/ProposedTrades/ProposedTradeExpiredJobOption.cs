namespace Memorabilia.Application.Hangfire.Jobs.ProposedTrades;

public class ProposedTradeExpiredJobOption 
    : HangfireJobOption<ProposedTradeExpiredJobOption>
{
    public override ProposedTradeExpiredJobOption Value
        => this;
}
