namespace Memorabilia.Application.Features.Services.Filters.Memorabilia.Rules;

public class LevelTypeFilterRule : IFilterRule<MemorabiliaItemViewModel>
{
    private int _levelTypeId;

    public bool Applies(FilterItemEnum filterItemEnum, object value)
    {
        if (filterItemEnum != FilterItemEnum.MemorabiliaLevelType)
            return false;

        _levelTypeId = (int)value;

        return _levelTypeId > 0;
    }

    public Expression<Func<MemorabiliaItemViewModel, bool>> GetExpression()
    {
        Expression<Func<MemorabiliaItemViewModel, bool>> expression = item => item.LevelTypeId == _levelTypeId;

        return expression;
    }
}
