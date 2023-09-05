namespace Memorabilia.Application.Features.ForSale;

public class ForSaleModel : Model
{
    public ForSaleModel() { }

    public ForSaleModel(IEnumerable<Entity.MemorabiliaForSale> memorabiliaForSale,
                        PageInfoResult pageInfo = null)
    {
        MemorabiliaForSale = memorabiliaForSale.Select(item => new ForSaleMemorabiliaModel(item))
                                               .ToList();

        PageInfo = pageInfo;
    }

    public List<ForSaleMemorabiliaModel> MemorabiliaForSale { get; set; }
        = new();
}
