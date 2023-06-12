﻿namespace Memorabilia.Application.Features.Services.Filters.Memorabilia.Rules;

public class ConditionFilterRule : IFilterRule<Entity.Memorabilia>
{
    private int[] _conditionIds;
    private FilterItemEnum _filterItem;

    public bool Applies(FilterItemEnum filterItem, object value)
    {
        if (filterItem != FilterItemEnum.AutographCondition &&
            filterItem != FilterItemEnum.MemorabiliaCondition)
            return false;

        _conditionIds = (int[])value;
        _filterItem = filterItem;

        return _conditionIds.Any();
    }

    public Expression<Func<Entity.Memorabilia, bool>> GetExpression()
        => _filterItem == FilterItemEnum.AutographCondition 
            ? item => item.Autographs.Any(autograph => _conditionIds.Contains(autograph.ConditionId)) 
            : item => _conditionIds.Contains(item.ConditionId ?? 0);
}
