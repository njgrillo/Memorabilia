namespace Memorabilia.Domain.Constants;

public sealed class ProposeTradeMemorabiliaType : DomainItemConstant
{
    public static readonly ProposeTradeMemorabiliaType Receive = new(1, "Receive");
    public static readonly ProposeTradeMemorabiliaType Send = new(2, "Send");

    public static readonly ProposeTradeMemorabiliaType[] All =
    {
        Receive,
        Send
    };

    private ProposeTradeMemorabiliaType(int id, string name, string abbreviation = null)
        : base(id, name, abbreviation) { }

    public static ProposeTradeMemorabiliaType Find(int id)
        => All.SingleOrDefault(proposeTradeMemorabiliaType => proposeTradeMemorabiliaType.Id == id);
}
