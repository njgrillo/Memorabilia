namespace Memorabilia.Domain.Entities;

public class ProposeTradeMemorabilia : Framework.Library.Domain.Entity.DomainEntity
{
    public ProposeTradeMemorabilia() { }

    public ProposeTradeMemorabilia(int memorabiliaId,
                                   int proposeTradeId,
                                   int proposeTradeMemorabiliaTypeId)
    {
        MemorabiliaId = memorabiliaId;
        ProposeTradeId = proposeTradeId;
        ProposeTradeMemorabiliaTypeId = proposeTradeMemorabiliaTypeId;
    }

    public virtual Memorabilia Memorabilia { get; private set; }

    public int MemorabiliaId { get; private set; }

    public int ProposeTradeId { get; private set; }

    public int ProposeTradeMemorabiliaTypeId { get; private set; }
}
