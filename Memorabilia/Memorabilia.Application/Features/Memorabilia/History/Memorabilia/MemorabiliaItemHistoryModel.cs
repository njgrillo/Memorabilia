namespace Memorabilia.Application.Features.Memorabilia.History.Memorabilia;

public class MemorabiliaItemHistoryModel
{
    private readonly Entity.Memorabilia _memorabilila;

    public MemorabiliaItemHistoryModel() { }

    public MemorabiliaItemHistoryModel(Entity.Memorabilia memorabiliaHistory)
    {
        _memorabilila = memorabiliaHistory;
    }

    //public DateTime? AcquiredDate
    //    => _memorabilila.Acquisition?.AcquiredDate;

    //public decimal? AcquisitionCost
    //    => _memorabilila.Acquisition?.Cost;

    //public string AcquisitionTypeName
    //    => Constant.AcquisitionType.Find(_memorabilila.Acquisition?.AcquisitionTypeId ?? 0)?.Name;

    public string ConditionName
        => _memorabilila.Condition?.Name;

    public decimal? EstimatedValue
        => _memorabilila.EstimatedValue;

    public string ItemTypeName
        => _memorabilila.ItemType?.Name;

    public string PrivacyTypeName
        => Constant.PrivacyType.Find(_memorabilila.PrivacyTypeId).Name;

    //public string PurchaseTypeName
    //    => Constant.PurchaseType.Find(_memorabilila.Acquisition?.PurchaseTypeId ?? 0).Name;
}
