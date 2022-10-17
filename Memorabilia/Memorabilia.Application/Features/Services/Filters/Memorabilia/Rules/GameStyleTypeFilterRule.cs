namespace Memorabilia.Application.Features.Services.Filters.Memorabilia.Rules;

public class GameStyleTypeFilterRule : IFilterRule<MemorabiliaItemViewModel>
{
    private int _gameStyleTypeId;

    public bool Applies(FilterItemEnum filterItemEnum, object value)
    {
        if (filterItemEnum != FilterItemEnum.MemorabiliaGameStyleType)
            return false;

        _gameStyleTypeId = (int)value;

        return _gameStyleTypeId > 0;
    }

    public Expression<Func<MemorabiliaItemViewModel, bool>> GetExpression()
    {
        Expression<Func<MemorabiliaItemViewModel, bool>> expression = item => item.GameStyleTypeId == _gameStyleTypeId;

        return expression;
    }
}
