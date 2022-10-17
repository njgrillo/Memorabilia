namespace Memorabilia.Application.Features.Services.Filters.Memorabilia.Rules;

public class ConditionFilterRule : IFilterRule<MemorabiliaItemViewModel>
{
    private int _conditionId;

    public bool Applies(FilterItemEnum filterItemEnum, object value)
    {
        if (filterItemEnum != FilterItemEnum.MemorabiliaCondition)
            return false;

        _conditionId = (int)value;

        return _conditionId > 0;
    }

    public Expression<Func<MemorabiliaItemViewModel, bool>> GetExpression()
    {
        Expression<Func<MemorabiliaItemViewModel, bool>> expression = item => item.ConditionId == _conditionId;

        return expression;
    }
}
