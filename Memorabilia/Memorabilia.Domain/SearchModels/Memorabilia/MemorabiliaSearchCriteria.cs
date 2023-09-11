namespace Memorabilia.Domain.SearchModels.Memorabilia;

public class MemorabiliaSearchCriteria : SearchCriteria
{
    public AutographSearchCriteria AutographSearchCriteria { get; set; } 
        = new();

    public Constant.BuyNowFilter BuyNowFilter { get; set; }
        = Constant.BuyNowFilter.None;

    public string BuyNowFilterName
        => BuyNowFilter.Name;

    public IEnumerable<int> BrandIds { get; set; } 
        = Enumerable.Empty<int>();    

    public IEnumerable<int> GameStyleTypeIds { get; set; } 
        = Enumerable.Empty<int>();

    public bool IncludeMyMemorablia { get; set; }

    public bool IncludeSold { get; set; }

    public bool IncludeTraded { get; set; }

    public IEnumerable<int> ItemTypeIds { get; set; } 
        = Enumerable.Empty<int>();

    public IEnumerable<int> LevelTypeIds { get; set; } 
        = Enumerable.Empty<int>();   
    
    public Constant.MakeOfferFilter MakeOfferFilter { get; set; }
        = Constant.MakeOfferFilter.None;

    public string MakeOfferFilterName
        => MakeOfferFilter.Name;

    public IEnumerable<int> PrivacyTypeIds { get; set; } 
        = Enumerable.Empty<int>();

    public Constant.SaleFilter SaleFilter { get; set; }
        = Constant.SaleFilter.None;

    public string SaleFilterName
        => SaleFilter.Name;

    public IEnumerable<int> SizeIds { get; set; } 
        = Enumerable.Empty<int>();

    public Constant.TradeFilter TradeFilter { get; set; }
        = Constant.TradeFilter.None;

    public string TradeFilterName
        => TradeFilter.Name;
}
