namespace Memorabilia.Application.Features.ForTrade;

public class ForTradeEditModel : EditModel
{
    public ForTradeEditModel() { }

    public ForTradeEditModel(ForTradeModel model)
    {
        Items = model.Memorabilia
                     .Select(item => new ForTradeMemorabiliaEditModel(item))
                     .ToList();
    }

    public List<ForTradeMemorabiliaEditModel> Items { get; set; }
        = [];
}
