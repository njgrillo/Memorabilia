namespace Memorabilia.Application.Features.ProposeTrade;

public class ProposeTradeMemorabiliaModel
{
	private readonly Entity.ProposeTradeMemorabilia _proposeTradeMemorabilia;

	public ProposeTradeMemorabiliaModel() { }

	public ProposeTradeMemorabiliaModel(Entity.ProposeTradeMemorabilia proposeTradeMemorabilia)
	{
		_proposeTradeMemorabilia = proposeTradeMemorabilia;
    }

	public int Id
		=> _proposeTradeMemorabilia.Id;

	public Entity.Memorabilia Memorabilia
		=> _proposeTradeMemorabilia.Memorabilia;

	public int MemorabiliaId
		=> _proposeTradeMemorabilia.MemorabiliaId;

	public int ProposeTradeId
		=> _proposeTradeMemorabilia.ProposeTradeId;

	public int ProposeTradeMemorabiliaTypeId
		=> _proposeTradeMemorabilia.ProposeTradeMemorabiliaTypeId;
}
