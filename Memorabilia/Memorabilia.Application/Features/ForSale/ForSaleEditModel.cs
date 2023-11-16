namespace Memorabilia.Application.Features.ForSale;

public class ForSaleEditModel : EditModel
{
    public ForSaleEditModel() { }

    public ForSaleEditModel(ForSaleModel model)
    {
        Items = model.MemorabiliaForSale
                     .Select(item => new ForSaleMemorabiliaEditModel(item))
                     .ToList();
    }

    public List<ForSaleMemorabiliaEditModel> Items { get; set; }
        = [];
}
