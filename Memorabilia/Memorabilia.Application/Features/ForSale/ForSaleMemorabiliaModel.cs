namespace Memorabilia.Application.Features.ForSale;

public class ForSaleMemorabiliaModel
{
    private readonly Entity.MemorabiliaForSale _memorabiliaForSale;

    public ForSaleMemorabiliaModel() { }

    public ForSaleMemorabiliaModel(Entity.MemorabiliaForSale memorabiliaForSale)
    {
        _memorabiliaForSale = memorabiliaForSale;
    }

    public bool AllowBestOffer
        => _memorabiliaForSale.AllowBestOffer;

    public decimal? BuyNowPrice
        => _memorabiliaForSale.BuyNowPrice;    

    public int Id
        => _memorabiliaForSale.Id;

    public string ImageDisplayCount
    {
        get
        {
            if (_memorabiliaForSale.Memorabilia.Images.IsNullOrEmpty())
                return "No Images Found";

            if (_memorabiliaForSale.Memorabilia.Images.Count == 1)
                return "1 Image";

            return $"{_memorabiliaForSale.Memorabilia.Images.Count} Images";
        }
    }

    public string ItemTypeName
        => _memorabiliaForSale.Memorabilia.ItemType?.Name;

    public Entity.Memorabilia Memorabilia
        => _memorabiliaForSale.Memorabilia;

    public int MemorabiliaId
        => _memorabiliaForSale.Memorabilia.Id;

    public string MemorabiliaPrimaryImage
        => _memorabiliaForSale.Memorabilia.Images.IsNullOrEmpty()
           ? Constant.ImageFileName.ImageNotAvailable
           : _memorabiliaForSale.Memorabilia.Images.FirstOrDefault(image => image.ImageTypeId == Constant.ImageType.Primary.Id)?.FileName
             ?? _memorabiliaForSale.Memorabilia.Images.First().FileName;

    public decimal? MinimumOfferPrice
        => _memorabiliaForSale.MinimumOfferPrice;

    public int UserId
        => _memorabiliaForSale.Memorabilia.UserId;
}
