namespace Memorabilia.Blazor.Models.Constants;

public static class EmailSubject
{
    public static string Offer
        => "Offer has been [[offerStatusType]]!";

    public static string OfferSent
        => "Offer sent!";

    public static string ProposeTrade
        => "Trade has been [[proposeTradeStatusType]]!";

    public static string ProposeTradeSent
        => "Trade proposal sent!";    
}
