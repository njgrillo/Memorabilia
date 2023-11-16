namespace Memorabilia.Application.Features.ForTrade;

public class ForTradeModel
{
    public ForTradeModel() { }

    public ForTradeModel(IEnumerable<Entity.Memorabilia> memorabilia)
    {
        Memorabilia = memorabilia.Select(item => new ForTradeMemorabiliaModel(item))
                                 .ToList();
    }

    public List<ForTradeMemorabiliaModel> Memorabilia { get; set; }
        = [];
}
