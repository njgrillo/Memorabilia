﻿namespace Memorabilia.Application.Features.Home;

public class HomeModel
{
	public HomeModel() { }

	public HomeModel(int userId,
					 Entity.ProposeTrade[] proposeTrades,
					 Entity.ProposeTrade[] acceptedProposedTrades,
                     Entity.Offer[] openOffers,
                     Entity.Offer[] acceptedOffers)
	{	
        AcceptedProposedTrades 
			= acceptedProposedTrades.Select(proposeTrade => new AcceptedProposedTradeModel(proposeTrade, userId))
                                    .ToArray();

        ProposedTrades 
            = proposeTrades.Select(proposeTrade => new OpenProposedTradeModel(proposeTrade, userId))
                           .ToArray();

        OpenOffers = openOffers.Select(offer => new OpenOfferModel(offer, userId))
                               .ToArray();

        AcceptedOffers = acceptedOffers.Select(offer => new AcceptedOfferModel(offer, userId))
                                       .ToArray();
    }

    public AcceptedOfferModel[] AcceptedOffers { get; set; }
        = Array.Empty<AcceptedOfferModel>();

    public AcceptedProposedTradeModel[] AcceptedProposedTrades { get; set; }
        = Array.Empty<AcceptedProposedTradeModel>();

    public OpenOfferModel[] OpenOffers { get; set; }
        = Array.Empty<OpenOfferModel>();

    public OpenProposedTradeModel[] ProposedTrades { get; set; }
		= Array.Empty<OpenProposedTradeModel>();
}
