namespace Memorabilia.Domain.SearchModels.Autographs;

public class AutographSearchCriteria : SearchCriteria
{
    public Constant.AuthenticationFilter AuthenticationFilter { get; set; } 
        = Constant.AuthenticationFilter.None;

    public string AuthenticationFilterName
        => AuthenticationFilter.Name;

    public IEnumerable<int> ColorIds { get; set; }
        = Enumerable.Empty<int>();

    public int? Grade { get; set; }

    public Constant.InscriptionFilter InscriptionFilter { get; set; } 
        = Constant.InscriptionFilter.None;

    public string InscriptionFilterName
        => InscriptionFilter.Name;

    public Constant.PersonalizationFilter PersonalizationFilter { get; set; } 
        = Constant.PersonalizationFilter.None;

    public string PersonalizationFilterName
        => PersonalizationFilter.Name;

    public IEnumerable<int> SpotIds { get; set; } 
        = Enumerable.Empty<int>();

    public IEnumerable<int> WritingInstrumentIds { get; set; } 
        = Enumerable.Empty<int>();

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        var criteria = (AutographSearchCriteria)obj;

        return AcquiredDateBegin.Equals(criteria.AcquiredDateBegin)
            && AcquiredDateEnd.Equals(criteria.AcquiredDateEnd)
            && AcquisitionTypeIds.Equals(criteria.AcquisitionTypeIds)
            && AuthenticationFilterName.Equals(criteria.AuthenticationFilterName)
            && AutographFilterName.Equals(criteria.AutographFilterName)
            && ColorIds.Equals(criteria.ColorIds)
            && ConditionIds.Equals(criteria.ConditionIds)
            && CostHigh.Equals(criteria.CostHigh)
            && CostLow.Equals(criteria.CostLow)
            && EstimatedValueHigh.Equals(criteria.EstimatedValueHigh)
            && EstimatedValueLow.Equals(criteria.EstimatedValueLow)
            && FranchiseIds.Equals(criteria.FranchiseIds)
            && Grade.Equals(criteria.Grade)
            && ImageFilterName.Equals(criteria.ImageFilterName)
            && InscriptionFilterName.Equals(criteria.InscriptionFilterName)
            && PersonalizationFilterName.Equals(criteria.PersonalizationFilterName)
            && PersonIds.Equals(criteria.PersonIds)
            && PurchaseTypeIds.Equals(criteria.PurchaseTypeIds)
            && SportIds.Equals(criteria.SportIds)
            && SportLeagueLevelIds.Equals(criteria.SportLeagueLevelIds)
            && SpotIds.Equals(criteria.SpotIds)
            && TeamIds.Equals(criteria.TeamIds)
            && WritingInstrumentIds.Equals(criteria.WritingInstrumentIds);
    }

    public override int GetHashCode()
        => base.GetHashCode() +
           AcquiredDateBegin.GetHashCode() +
           AcquiredDateEnd.GetHashCode() +
           AcquisitionTypeIds.GetHashCode() +
           AuthenticationFilterName.GetHashCode() +
           AutographFilterName.GetHashCode() +
           ColorIds.GetHashCode() +
           ConditionIds.GetHashCode() +
           CostHigh.GetHashCode() +
           CostLow.GetHashCode() +
           EstimatedValueHigh.GetHashCode() +
           EstimatedValueLow.GetHashCode() +
           FranchiseIds.GetHashCode() +
           Grade.GetHashCode() +
           ImageFilterName.GetHashCode() +
           InscriptionFilterName.GetHashCode() +
           PersonalizationFilterName.GetHashCode() +
           PersonIds.GetHashCode() +
           PurchaseTypeIds.GetHashCode() +
           SportIds.GetHashCode() +
           SportLeagueLevelIds.GetHashCode() +
           SpotIds.GetHashCode() +
           TeamIds.GetHashCode() +
           WritingInstrumentIds.GetHashCode();
}
