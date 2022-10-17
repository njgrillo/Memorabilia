namespace Memorabilia.Application.Features.Services.Filters.Memorabilia.Rules;

public class PrivacyTypeFilterRule : IFilterRule<MemorabiliaItemViewModel>
{
    private int _privacyTypeId;

    public bool Applies(FilterItemEnum filterItemEnum, object value)
    {
        if (filterItemEnum != FilterItemEnum.MemorabiliaPrivacyType)
            return false;

        _privacyTypeId = (int)value;

        return _privacyTypeId > 0;
    }

    public Expression<Func<MemorabiliaItemViewModel, bool>> GetExpression()
    {
        Expression<Func<MemorabiliaItemViewModel, bool>> expression = item => item.PrivacyTypeId == _privacyTypeId;

        return expression;
    }
}
