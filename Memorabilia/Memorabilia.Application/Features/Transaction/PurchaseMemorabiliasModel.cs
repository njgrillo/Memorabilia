namespace Memorabilia.Application.Features.Transaction;

public class PurchaseMemorabiliasModel : Model
{
    public PurchaseMemorabiliasModel() { }

    public PurchaseMemorabiliasModel(IEnumerable<Entity.Memorabilia> memorabiliaItems,
                                     PageInfoResult pageInfo = null)
    {
        MemorabiliaItems = memorabiliaItems.Select(memorabiliaItem => new PurchaseMemorabiliaModel(memorabiliaItem))
                                           .ToList();

        PageInfo = pageInfo;
    }

    public List<PurchaseMemorabiliaModel> MemorabiliaItems { get; set; }
        = new();
}
