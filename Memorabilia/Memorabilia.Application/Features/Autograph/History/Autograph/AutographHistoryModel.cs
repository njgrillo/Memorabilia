namespace Memorabilia.Application.Features.Autograph.History.Autograph;

public class AutographHistoryModel
{
    private readonly Entity.Autograph _autograph;

    public AutographHistoryModel() { }

    public AutographHistoryModel(Entity.Autograph autographHistory)
    {
        _autograph = autographHistory;
    }

    public string ColorName
        => Constant.Color.Find(_autograph.ColorId)?.Name;

    public string ConditionName
        => Constant.Condition.Find(_autograph.ConditionId)?.Name;

    public decimal? EstimatedValue
        => _autograph.EstimatedValue;

    public string Note
        => _autograph.Note;

    public string SerialNumber
        => _autograph.Numerator.HasValue && _autograph.Denominator.HasValue
        ? $"{_autograph.Numerator}/{_autograph.Denominator}"
        : string.Empty;

    public string WritingInstrumentName
        => Constant.WritingInstrument.Find(_autograph.WritingInstrumentId)?.Name;
}
