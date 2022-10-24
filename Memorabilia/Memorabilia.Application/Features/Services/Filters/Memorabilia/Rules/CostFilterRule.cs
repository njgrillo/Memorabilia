using MudBlazor;

namespace Memorabilia.Application.Features.Services.Filters.Memorabilia.Rules;

public class CostFilterRule : IFilterRule<MemorabiliaItemViewModel>
{
    private Range<decimal?> _range;

    public bool Applies(FilterItemEnum filterItemEnum, object value)
    {
        if (filterItemEnum != FilterItemEnum.MemorabiliaCost)
            return false;

        _range = (Range<decimal?>)value;

        return _range.Start.HasValue || _range.End.HasValue;
    }

    public Expression<Func<MemorabiliaItemViewModel, bool>> GetExpression()
    {
        Expression<Func<MemorabiliaItemViewModel, bool>> expression = item => item.Acquisition.Cost >= (_range.Start ?? 0) && item.Acquisition.Cost <= (_range.End ?? decimal.MaxValue);

        return expression;
    }
}
