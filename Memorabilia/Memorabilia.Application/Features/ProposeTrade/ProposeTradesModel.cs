namespace Memorabilia.Application.Features.ProposeTrade;

public class ProposeTradesModel : Model
{
    public ProposeTradesModel() { }

    public ProposeTradesModel(IEnumerable<Entity.ProposeTrade> proposedTrades, int userId)
    {
        ProposedTrades = proposedTrades.Select(trade => new ProposeTradeModel(trade, userId))
                                       .ToArray();

        UserId = userId;
    }

    public ProposeTradeModel[] CompletedTrades
        => ProposedTrades.Where(trade => trade.ProposeTradeStatusTypeId == Constant.ProposeTradeStatusType.Accepted.Id
                                      || trade.ProposeTradeStatusTypeId == Constant.ProposeTradeStatusType.Canceled.Id
                                      || trade.ProposeTradeStatusTypeId == Constant.ProposeTradeStatusType.Countered.Id
                                      || trade.ProposeTradeStatusTypeId == Constant.ProposeTradeStatusType.Expired.Id
                                      || trade.ProposeTradeStatusTypeId == Constant.ProposeTradeStatusType.Rejected.Id)
                         .ToArray();

    public int CompletedTradesCount
        => CompletedTrades.Length;

    public override string ItemTitle
        => "ProposeTrade";

    public ProposeTradeModel[] OpenTrades
        => ProposedTrades.Where(trade => trade.ProposeTradeStatusTypeId == Constant.ProposeTradeStatusType.Pending.Id)
                         .ToArray();

    public int OpenTradesCount
     => OpenTrades.Length;

    public override string PageTitle
        => "Proposed Trades";

    public ProposeTradeModel[] ProposedTrades { get; set; }
        = [];

    public int UserId { get; private set; }
}
