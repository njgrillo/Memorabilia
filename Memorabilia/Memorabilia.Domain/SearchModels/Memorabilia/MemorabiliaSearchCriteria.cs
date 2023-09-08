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

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType()) 
            return false;
        
        var criteria = (MemorabiliaSearchCriteria)obj;
        
        return AcquiredDateBegin.Equals(criteria.AcquiredDateBegin)
            && AcquiredDateEnd.Equals(criteria.AcquiredDateEnd)
            && AcquisitionTypeIds.Equals(criteria.AcquisitionTypeIds)
            && AutographFilterName.Equals(criteria.AutographFilterName)
            && AutographSearchCriteria.Equals(criteria.AutographSearchCriteria)
            && BrandIds.Equals(criteria.BrandIds)
            && BuyNowFilterName.Equals(criteria.BuyNowFilterName)
            && ConditionIds.Equals(criteria.ConditionIds)
            && CostHigh.Equals(criteria.CostHigh)
            && CostLow.Equals(criteria.CostLow)
            && EstimatedValueHigh.Equals(criteria.CostLow)
            && EstimatedValueLow.Equals(criteria.CostLow)
            && FranchiseIds.Equals(criteria.CostLow)
            && GameStyleTypeIds.Equals(criteria.GameStyleTypeIds)
            && ImageFilterName.Equals(criteria.ImageFilterName)
            && IncludeMyMemorablia.Equals(criteria.IncludeMyMemorablia)
            && IncludeSold.Equals(criteria.IncludeSold)
            && IncludeTraded.Equals(criteria.IncludeTraded)
            && ItemTypeIds.Equals(criteria.ItemTypeIds)
            && LevelTypeIds.Equals(criteria.LevelTypeIds)
            && MakeOfferFilterName.Equals(criteria.MakeOfferFilterName)
            && PersonIds.Equals(criteria.LevelTypeIds)
            && PrivacyTypeIds.Equals(criteria.PrivacyTypeIds)
            && PurchaseTypeIds.Equals(criteria.PurchaseTypeIds)
            && SaleFilterName.Equals(criteria.SaleFilterName)
            && SizeIds.Equals(criteria.SizeIds)
            && SportIds.Equals(criteria.SportIds)
            && SportLeagueLevelIds.Equals(criteria.SportLeagueLevelIds)
            && TeamIds.Equals(criteria.TeamIds)
            && TradeFilterName.Equals(criteria.TradeFilterName);
    }

    public override int GetHashCode()
        => base.GetHashCode() +
           AcquiredDateBegin.GetHashCode() +
           AcquiredDateEnd.GetHashCode() +
           AcquisitionTypeIds.GetHashCode() +
           AutographFilterName.GetHashCode() +
           AutographSearchCriteria.GetHashCode() +
           BrandIds.GetHashCode() +
           BuyNowFilterName.GetHashCode() +
           ConditionIds.GetHashCode() +
           CostHigh.GetHashCode() +
           CostLow.GetHashCode() +
           EstimatedValueHigh.GetHashCode() +
           EstimatedValueLow.GetHashCode() +
           FranchiseIds.GetHashCode() +
           GameStyleTypeIds.GetHashCode() +
           ImageFilterName.GetHashCode() +
           IncludeMyMemorablia.GetHashCode() +
           IncludeSold.GetHashCode() +
           IncludeTraded.GetHashCode() +
           ItemTypeIds.GetHashCode() +
           LevelTypeIds.GetHashCode() +
           MakeOfferFilterName.GetHashCode() +
           PersonIds.GetHashCode() +
           PrivacyTypeIds.GetHashCode() +
           PurchaseTypeIds.GetHashCode() +
           SaleFilterName.GetHashCode() +
           SizeIds.GetHashCode() +
           SportIds.GetHashCode() +
           SportLeagueLevelIds.GetHashCode() +
           TeamIds.GetHashCode() +
           TradeFilterName.GetHashCode();
}
