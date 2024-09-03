namespace Memorabilia.Application.Features.Memorabilia.History.Memorabilia;

public class MemorabiliaItemHistoryModel
{
    private readonly Entity.Memorabilia _memorabilila;

    public MemorabiliaItemHistoryModel() { }

    public MemorabiliaItemHistoryModel(Entity.Memorabilia memorabiliaHistory)
    {
        _memorabilila = memorabiliaHistory;
    }

    public string ConditionName
        => _memorabilila.Condition?.Name;

    public decimal? EstimatedValue
        => _memorabilila.EstimatedValue;

    public bool ForTrade
        => _memorabilila.ForTrade;

    public bool Framed
        => _memorabilila.Framed;

    public string ItemTypeName
        => _memorabilila.ItemType?.Name;

    public string Note
        => _memorabilila.Note;

    public string PrivacyTypeName
        => Constant.PrivacyType.Find(_memorabilila.PrivacyTypeId).Name;

    public string SerialNumber
        => _memorabilila.Numerator.HasValue && _memorabilila.Denominator.HasValue
        ? $"{_memorabilila.Numerator}/{_memorabilila.Denominator}"
        : string.Empty;
}
