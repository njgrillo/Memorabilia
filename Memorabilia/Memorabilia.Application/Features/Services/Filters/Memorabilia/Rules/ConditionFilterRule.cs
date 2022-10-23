using System.Linq;

namespace Memorabilia.Application.Features.Services.Filters.Memorabilia.Rules;

public class ConditionFilterRule : IFilterRule<MemorabiliaItemViewModel>
{
    private int[] _conditionIds;

    public bool Applies(FilterItemEnum filterItemEnum, object value)
    {
        if (filterItemEnum != FilterItemEnum.MemorabiliaCondition)
            return false;

        _conditionIds = (int[])value;

        return _conditionIds.Any();
    }

    public Expression<Func<MemorabiliaItemViewModel, bool>> GetExpression()
    {
        Expression<Func<MemorabiliaItemViewModel, bool>> expression = item => _conditionIds.Contains(item.ConditionId ?? 0);

        return expression;
    }
}
