namespace Memorabilia.Application.Features.Services.Filters.Autographs.Rules;

public class WritingInstrumentFilterRule : IFilterRule<AutographViewModel>
{
    private int[] _writingInstrumentIds;

    public bool Applies(FilterItemEnum filterItemEnum, object value)
    {
        if (filterItemEnum != FilterItemEnum.AutographWritingInstrument)
            return false;

        _writingInstrumentIds = (int[])value;

        return _writingInstrumentIds.Any();
    }

    public Expression<Func<AutographViewModel, bool>> GetExpression()
    {
        Expression<Func<AutographViewModel, bool>> expression = autograph => _writingInstrumentIds.Contains(autograph.WritingInstrumentId);

        return expression;
    }
}
