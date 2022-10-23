namespace Memorabilia.Application.Features.Services.Filters.Memorabilia.Rules;

public class GameStyleTypeFilterRule : IFilterRule<MemorabiliaItemViewModel>
{
    private int[] _gameStyleTypeIds;

    public bool Applies(FilterItemEnum filterItemEnum, object value)
    {
        if (filterItemEnum != FilterItemEnum.MemorabiliaGameStyleType)
            return false;

        _gameStyleTypeIds = (int[])value;

        return _gameStyleTypeIds.Any();
    }

    public Expression<Func<MemorabiliaItemViewModel, bool>> GetExpression()
    {
        Expression<Func<MemorabiliaItemViewModel, bool>> expression = item => _gameStyleTypeIds.Contains(item.GameStyleTypeId ?? 0);

        return expression;
    }
}
