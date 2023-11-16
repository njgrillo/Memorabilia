namespace Memorabilia.Application.Features.ProposeTrade;

[AuthorizeByPermission(Enum.Permission.BuySellTrade)]
public record UpdateProposeTradeStatus(int ProposeTradeId, Constant.ProposeTradeStatusType Status)
     : ICommand
{
    public class Handler(IProposeTradeRepository proposeTradeRepository) 
        : CommandHandler<UpdateProposeTradeStatus>
    {
        protected override async Task Handle(UpdateProposeTradeStatus command)
        {
            Entity.ProposeTrade proposeTrade 
                = await proposeTradeRepository.Get(command.ProposeTradeId);

            proposeTrade.SetStatus(command.Status);

            await proposeTradeRepository.Update(proposeTrade);
        }
    }
}
