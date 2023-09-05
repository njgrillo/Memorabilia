namespace Memorabilia.Application.Features.ForSale;

public class ForSaleMemorabiliaEditModel : EditModel
{
    public ForSaleMemorabiliaEditModel() { }

    public ForSaleMemorabiliaEditModel(ForSaleMemorabiliaModel model)
    {
        AllowBestOffer = model.AllowBestOffer;
        BuyNowPrice = model.BuyNowPrice;
        Id = model.Id;
        ItemTypeName = model.ItemTypeName;
        Memorabilia = model.Memorabilia;
        MemorabiliaId = model.MemorabiliaId;
        MemorabiliaPrimaryImage = model.MemorabiliaPrimaryImage;
        MinimumOfferPrice = model.MinimumOfferPrice;
        UserId = model.UserId;
    }

    public bool AllowBestOffer { get; set; }

    public decimal? BuyNowPrice { get; set; }

    public bool IsSelected { get; set; }

    public string ItemTypeName { get; set; }

    public Entity.Memorabilia Memorabilia { get; }

    public int MemorabiliaId { get; set; }  

    public string MemorabiliaPrimaryImage { get; set; }

    public decimal? MinimumOfferPrice { get; set; }

    public string ToggleIcon { get; set; }
        = MudBlazor.Icons.Material.Filled.ExpandMore;

    public int UserId { get; }
}
