namespace Memorabilia.Application.Features.Services.Filters.Memorabilia.Rules;

public class CostFilterRule : IFilterRule<MemorabiliaItemViewModel>
{
    private decimal? _cost;

    public bool Applies(FilterItemEnum filterItemEnum, object value)
    {
        if (filterItemEnum != FilterItemEnum.MemorabiliaCost)
            return false;

        _cost = (decimal?)value;

        return _cost.HasValue && _cost.Value > 0;
    }

    public Expression<Func<MemorabiliaItemViewModel, bool>> GetExpression()
    {
        Expression<Func<MemorabiliaItemViewModel, bool>> expression = item => item.Acquisition.Cost == _cost;

        return expression;
    }
}
