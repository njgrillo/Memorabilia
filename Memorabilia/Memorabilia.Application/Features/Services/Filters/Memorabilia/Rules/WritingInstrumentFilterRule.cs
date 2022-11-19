namespace Memorabilia.Application.Features.Services.Filters.Memorabilia.Rules;

public class WritingInstrumentFilterRule : IFilterRule<Domain.Entities.Memorabilia>
{
    private int[] _writingInstrumentIds;

    public bool Applies(FilterItemEnum filterItem, object value)
    {
        if (filterItem != FilterItemEnum.AutographWritingInstrument)
            return false;

        _writingInstrumentIds = (int[])value;

        return _writingInstrumentIds.Any();
    }

    public Expression<Func<Domain.Entities.Memorabilia, bool>> GetExpression()
    {
        return item => item.Autographs.Any(autograph => _writingInstrumentIds.Contains(autograph.WritingInstrumentId));
    }
}
