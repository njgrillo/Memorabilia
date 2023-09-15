namespace Memorabilia.Application.Features.Offer;

public class OfferMemorabiliaModel
{
    private readonly Entity.Memorabilia _memorabilia;

    public OfferMemorabiliaModel() { }

    public OfferMemorabiliaModel(Entity.Memorabilia memorabilia)
    {
        _memorabilia = memorabilia;
    }

    public List<AutographModel> Autographs
        => _memorabilia.Autographs
                       .Select(autograph => new AutographModel(autograph))
                       .ToList();

    public int AutographsCount
        => _memorabilia.Autographs.Count;

    public decimal? BuyNowPrice
        => _memorabilia.ForSale?.BuyNowPrice;

    public string ConditionName
        => _memorabilia.Condition?.Name;

    public bool DisplayAutographDetails { get; set; }

    public string ImageFileName
       => !_memorabilia.Images.Any()
       ? Constant.ImageFileName.ImageNotAvailable
       : _memorabilia.Images
                     .FirstOrDefault(image => image.ImageTypeId == Constant.ImageType.Primary.Id)?.FileName ?? _memorabilia.Images.First().FileName;

    public bool IsForSale
       => (_memorabilia.ForSale?.BuyNowPrice.HasValue ?? false) || (_memorabilia.ForSale?.AllowBestOffer ?? false);

    public string ItemTypeName
        => _memorabilia.ItemType?.Name;

    public int MemorabiliaId
        => _memorabilia.Id;

    public string Note
        => _memorabilia.Note;

    public int OfferId { get; set; }

    public string ToggleIcon { get; set; }
        = MudBlazor.Icons.Material.Filled.ExpandMore;

    public int UserId 
        => _memorabilia.UserId;
}
