namespace Memorabilia.Application.Services.Filters.Memorabilia.Rules;

public class WritingInstrumentFilterRule : IFilterRule<Entity.Memorabilia>
{
    private int[] _writingInstrumentIds;

    public bool Applies(FilterItemEnum filterItem, object value)
    {
        if (filterItem != FilterItemEnum.AutographWritingInstrument)
            return false;

        _writingInstrumentIds = (int[])value;

        return _writingInstrumentIds.Any();
    }

    public Expression<Func<Entity.Memorabilia, bool>> GetExpression()
        => item => item.Autographs.Any(autograph => _writingInstrumentIds.Contains(autograph.WritingInstrumentId));
}
