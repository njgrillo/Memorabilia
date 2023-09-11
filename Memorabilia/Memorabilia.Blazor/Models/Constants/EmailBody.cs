namespace Memorabilia.Blazor.Models.Constants;

public static class EmailBody
{
    public static string ProposeTrade
        => "The trade with [[tradePartnerName]] has been [[proposeTradeStatusType]]!";

    public static string ProposeTradeSent
        => "A trade has been proposed to you by [[userName]]!";
}
