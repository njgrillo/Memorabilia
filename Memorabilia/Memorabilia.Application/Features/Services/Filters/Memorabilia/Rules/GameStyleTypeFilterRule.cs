namespace Memorabilia.Application.Features.Services.Filters.Memorabilia.Rules;

public class GameStyleTypeFilterRule : IFilterRule<Entity.Memorabilia>
{
    private int[] _gameStyleTypeIds;

    public bool Applies(FilterItemEnum filterItem, object value)
    {
        if (filterItem != FilterItemEnum.MemorabiliaGameStyleType)
            return false;

        _gameStyleTypeIds = (int[])value;

        return _gameStyleTypeIds.Any();
    }

    public Expression<Func<Entity.Memorabilia, bool>> GetExpression()
    {
        return item => _gameStyleTypeIds.Contains(item.Game.GameStyleTypeId);
    }
}
