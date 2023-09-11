namespace Memorabilia.Domain.Entities;

public class ProposeTradeMemorabilia : Framework.Library.Domain.Entity.DomainEntity
{
    public ProposeTradeMemorabilia() { }

    public ProposeTradeMemorabilia(int memorabiliaId,
                                   int proposeTradeId,
                                   int userId)
    {
        MemorabiliaId = memorabiliaId;
        ProposeTradeId = proposeTradeId;
        UserId = userId;
    }

    public virtual Memorabilia Memorabilia { get; private set; }

    public int MemorabiliaId { get; private set; }

    public int ProposeTradeId { get; private set; }

    public virtual User User { get; private set; }

    public int UserId { get; private set; }
}
