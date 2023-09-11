namespace Memorabilia.Application.Features.Home;

public class HomeModel
{
	public HomeModel() { }

	public HomeModel(int userId,
					 Entity.ProposeTrade[] proposeTrades,
					 Entity.ProposeTrade[] acceptedProposedTrades)
	{
		ProposedTrades = proposeTrades.Select(proposeTrade => new OpenProposedTradeModel(proposeTrade, userId))
								      .ToArray();

        AcceptedProposedTrades 
			= acceptedProposedTrades.Select(proposeTrade => new AcceptedProposedTradeModel(proposeTrade, userId))
                                    .ToArray();
    }

    public AcceptedProposedTradeModel[] AcceptedProposedTrades { get; set; }
        = Array.Empty<AcceptedProposedTradeModel>();

    public OpenProposedTradeModel[] ProposedTrades { get; set; }
		= Array.Empty<OpenProposedTradeModel>();
}
