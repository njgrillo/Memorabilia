namespace Memorabilia.Application.Features.ProposeTrade;

public class ProposeTradeMemorabiliaEditModel : EditModel
{
    private readonly Entity.Memorabilia _memorabilia;

    public ProposeTradeMemorabiliaEditModel(Entity.Memorabilia memorabilia)
    {
        _memorabilia = memorabilia;

        UserId = memorabilia.UserId;

        ProposeTradeMemorabiliaTypeId
            = _memorabilia.User.Id == UserId
            ? Constant.ProposeTradeMemorabiliaType.Send.Id
            : Constant.ProposeTradeMemorabiliaType.Receive.Id;
    }

    public ProposeTradeMemorabiliaEditModel(Entity.ProposeTradeMemorabilia proposeTradeMemorabilia)
    {
        _memorabilia = proposeTradeMemorabilia.Memorabilia;

        Id = proposeTradeMemorabilia.Id;
        ProposeTradeId = proposeTradeMemorabilia.ProposeTradeId;
        UserId = proposeTradeMemorabilia.UserId;

        ProposeTradeMemorabiliaTypeId 
            = _memorabilia.User.Id == UserId 
            ? Constant.ProposeTradeMemorabiliaType.Send.Id
            : Constant.ProposeTradeMemorabiliaType.Receive.Id;    
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

    public int ProposeTradeId { get; set; }

    public Constant.ProposeTradeMemorabiliaType ProposeTradeMemorabiliaType
        => Constant.ProposeTradeMemorabiliaType.Find(ProposeTradeMemorabiliaTypeId);

    public int ProposeTradeMemorabiliaTypeId { get; set; }

    public string ProposeTradeMemorabiliaName
        => ProposeTradeMemorabiliaType?.Name;

    public string ToggleIcon { get; set; }
        = MudBlazor.Icons.Material.Filled.ExpandMore;

    public int UserId { get; set; }
}
