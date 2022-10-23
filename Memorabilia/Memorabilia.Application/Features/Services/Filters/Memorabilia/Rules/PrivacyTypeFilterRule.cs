namespace Memorabilia.Application.Features.Services.Filters.Memorabilia.Rules;

public class PrivacyTypeFilterRule : IFilterRule<MemorabiliaItemViewModel>
{
    private int[] _privacyTypeIds;

    public bool Applies(FilterItemEnum filterItemEnum, object value)
    {
        if (filterItemEnum != FilterItemEnum.MemorabiliaPrivacyType)
            return false;

        _privacyTypeIds = (int[])value;

        return _privacyTypeIds.Any();
    }

    public Expression<Func<MemorabiliaItemViewModel, bool>> GetExpression()
    {
        Expression<Func<MemorabiliaItemViewModel, bool>> expression = item => _privacyTypeIds.Contains(item.PrivacyTypeId);

        return expression;
    }
}
