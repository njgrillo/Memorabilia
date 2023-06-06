namespace Memorabilia.Application.Features.Services.Filters.Memorabilia.Rules;

public class LevelTypeFilterRule : IFilterRule<Entity.Memorabilia>
{
    private int[] _levelTypeIds;

    public bool Applies(FilterItemEnum filterItem, object value)
    {
        if (filterItem != FilterItemEnum.MemorabiliaLevelType)
            return false;

        _levelTypeIds = (int[])value;

        return _levelTypeIds.Any();
    }

    public Expression<Func<Entity.Memorabilia, bool>> GetExpression()
    {
        return item => _levelTypeIds.Contains(item.LevelType.LevelTypeId);
    }
}
