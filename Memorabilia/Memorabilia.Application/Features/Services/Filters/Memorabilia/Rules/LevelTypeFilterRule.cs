namespace Memorabilia.Application.Features.Services.Filters.Memorabilia.Rules;

public class LevelTypeFilterRule : IFilterRule<MemorabiliaItemViewModel>
{
    private int[] _levelTypeIds;

    public bool Applies(FilterItemEnum filterItemEnum, object value)
    {
        if (filterItemEnum != FilterItemEnum.MemorabiliaLevelType)
            return false;

        _levelTypeIds = (int[])value;

        return _levelTypeIds.Any();
    }

    public Expression<Func<MemorabiliaItemViewModel, bool>> GetExpression()
    {
        Expression<Func<MemorabiliaItemViewModel, bool>> expression = item => _levelTypeIds.Contains(item.LevelTypeId ?? 0);

        return expression;
    }
}
