namespace Memorabilia.Application.Features.Services.Filters.Autographs.Rules;

public class WritingInstrumentFilterRule : IFilterRule<AutographViewModel>
{
    private int _writingInstrumentId;

    public bool Applies(FilterItemEnum filterItemEnum, object value)
    {
        if (filterItemEnum != FilterItemEnum.AutographWritingInstrument)
            return false;

        _writingInstrumentId = (int)value;

        return _writingInstrumentId > 0;
    }

    public Expression<Func<AutographViewModel, bool>> GetExpression()
    {
        Expression<Func<AutographViewModel, bool>> expression = autograph => autograph.WritingInstrumentId == _writingInstrumentId;

        return expression;
    }
}
